using RestSharp;
using Sync2._0.Data;
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
        private readonly RestClient _client;

        public SynchronizationService(ApplicationDbContext context)
        {
            _context = context;
            _client = new RestClient("http://localhost:3267");
        }

        public void Sync()
        {
            foreach (var projectTable in _context.ProjectTables.Where(p => p.SyncStatus == false))
            {
                var request = new RestRequest("api/ProjectTables", Method.POST);
                request.AddJsonBody(projectTable);

                var response = _client.Execute<int>(request);

                if (response.IsSuccessful)
                {
                    projectTable.SyncStatus = true;
                    projectTable.RowVersion = response.Data;

                }
            }
            _context.SaveChanges();
        }
    }
}
