using RestSharp;
using Sync2._0.Data;
using Sync2._0.Models;
using Sync2._0.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sync2._0.Repositories;

namespace Sync2._0.Services
{
    public class SyncService
    {
        private RestClient _client;
        private readonly DbTableRepository _dbTableRepository;

        public SyncService(DbTableRepository dbTableRepository)
        {
            _client = new RestClient("https://localhost:44305/");
            _dbTableRepository = dbTableRepository;
        }

        public void Sync(IEnumerable<SyncEntity> syncEntities)
        {
            SyncSchema();
            SyncEntities(syncEntities);
        }

        private void SyncEntities(IEnumerable<SyncEntity> syncEntities)
        {
            var maxSync = syncEntities
                .Select(s => s.RowVersion)
                .DefaultIfEmpty(0)
                .Max();


            var changes = syncEntities
                .Where(s => s.SyncStatus == false);

            var request = new RestRequest("api/DynamicEntities/{maxSync}", Method.POST);
            request.JsonSerializer = new Serializers.JsonSerializer();
            request.AddUrlSegment("maxSync", maxSync);
            request.AddJsonBody(changes);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                var pulledData = JsonConvert.DeserializeObject<List<SyncEntity>>(response.Content);
                using (var context = new ApplicationDbContext())
                {
                    foreach (var syncEntitiy in pulledData)
                    {
                        syncEntitiy.SyncStatus = true;
                        _dbTableRepository.InsertOrReplace(syncEntitiy);
                    }
                }
            }
        }

        private void SyncSchema()
        {
            ICollection<SchemaDefinition> changes = GetSchemaDefinitionChanges();
            var maxSync = GetMaxSync();

            var request = new RestRequest("api/SchemaDefinitions/{maxSync}", Method.POST);
            request.JsonSerializer = new Serializers.JsonSerializer();
            request.AddUrlSegment("maxSync", maxSync);
            request.AddJsonBody(changes);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                var pulledData = JsonConvert.DeserializeObject<List<SchemaDefinition>>(response.Content);
                using (var context = new ApplicationDbContext())
                {
                    foreach (var schemaDefinition in pulledData)
                    {
                        schemaDefinition.SyncStatus = true;

                        if (context.SchemaDefinitions.Any(e => e.Id == schemaDefinition.Id))
                        {
                            context.Entry(schemaDefinition).State = EntityState.Modified;
                        }
                        else
                        {
                            context.SchemaDefinitions.Add(schemaDefinition);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private int GetMaxSync()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SchemaDefinitions
                    .Select(b => b.RowVersion)
                    .DefaultIfEmpty(0)
                    .Max();
            }
        }

        private ICollection<SchemaDefinition> GetSchemaDefinitionChanges()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SchemaDefinitions
                    .Where(b => b.SyncStatus == false)
                    .Include(b => b.ProjectTable)
                    .ThenInclude(p => p.Project)
                    .ToList();
            }
        }
    }
}
