﻿using RestSharp;
using Sync2._0.Data;
using Sync2._0.Models;
using Sync2._0.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Services
{
    public class SyncService
    {
        private RestClient _client;

        public SyncService()
        {
            _client = new RestClient("https://localhost:44370/");
        }

        public void Sync()
        {
            SyncSchema();
        }

        private void SyncSchema()
        {
            ICollection<SchemaDefinition> changes = GetChanges();
            var maxSync = GetMaxSync();

            var request = new RestRequest("api/schemadefinitions/{maxSync}", Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.AddUrlSegment("maxSync", maxSync);
            request.AddJsonBody(changes);

            var response = _client.Execute<List<SchemaDefinition>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    foreach (var item in response.Data)
                    {
                        item.SyncStatus = true;

                        if (context.SchemaDefinitions.Any(e => e.Id == item.Id))
                        {
                            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                        else
                        {
                            context.SchemaDefinitions.Add(item);
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

        private ICollection<SchemaDefinition> GetChanges()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SchemaDefinitions
                    .Where(b => b.SyncStatus == false)
                    .ToList();
            }
        }
    }
}