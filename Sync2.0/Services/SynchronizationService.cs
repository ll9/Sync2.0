using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;
using Sync2._0.Data;
using Sync2._0.Facades;
using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Services
{
    public class SynchronizationService
    {
        private readonly ApplicationDbContext _context;
        private readonly DDLFacade _ddLFacade;
        private readonly RestClient _client;

        public SynchronizationService(ApplicationDbContext context, DDLFacade dDLFacade)
        {
            _context = context;
            _ddLFacade = dDLFacade;
            _client = new RestClient("https://localhost:44305");
        }

        public void Sync()
        {
            DownloadProjectTableChanges();
            UploadProjectTableChanges();
        }

        private void UploadProjectTableChanges()
        {
            foreach (var projectTable in _context.ProjectTables.Where(p => p.SyncStatus == false))
            {
                var method = projectTable.RowVersion == 0 ? Method.POST : Method.PUT;
                var request = new RestSharp.Serializers.Newtonsoft.Json.RestRequest("api/ProjectTables", method);
                request.AddJsonBody(projectTable);
                var json = JsonConvert.SerializeObject(projectTable);

                var response = _client.Execute<int>(request);

                if (response.IsSuccessful)
                {
                    projectTable.SyncStatus = true;
                    projectTable.RowVersion = response.Data;

                }
            }
            _context.SaveChanges();
        }

        public void DownloadProjectTableChanges()
        {
            bool isUpToDate = false;

            do
            {
                var maxRowVersion = _context.ProjectTables
                    .Select(p => p.RowVersion)
                    .DefaultIfEmpty(0)
                    .Max();

                var request = new RestSharp.Serializers.Newtonsoft.Json.RestRequest("api/ProjectTables/{rowVersion}", Method.GET);
                request.AddUrlSegment("rowVersion", maxRowVersion);

                var response = _client.Execute<ProjectTable>(request);

                if (response.IsSuccessful)
                {
                    if (response.Data == null)
                    {
                        isUpToDate = true;
                    }
                    else
                    {
                        Merge(response.Data);
                    }
                }
                _context.SaveChanges();
            } while (!isUpToDate);
        }

        private void Merge(ProjectTable remoteProjectTable)
        {
            var projectTableInContext = _context.ProjectTables.SingleOrDefault(p => p.Name == remoteProjectTable.Name);

            if (projectTableInContext == null)
            {
                _ddLFacade.AddTable(remoteProjectTable);
            }
            else
            {
                foreach (var keyValuePair in remoteProjectTable.JsonDict)
                {
                    if (projectTableInContext.JsonDict.ContainsKey(keyValuePair.Key))
                    {
                        if (keyValuePair.Value.DataType != projectTableInContext.JsonDict[keyValuePair.Key].DataType)
                        {
                            throw new Exception("Merge Conflict");
                        }
                    }
                    else
                    {
                        _ddLFacade.AddColumn(remoteProjectTable.Name, keyValuePair.Key, keyValuePair.Value.DataType);
                        _context.ProjectTables.Single(p => p.Name.Equals(remoteProjectTable.Name, StringComparison.OrdinalIgnoreCase)).RowVersion = remoteProjectTable.RowVersion;
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
