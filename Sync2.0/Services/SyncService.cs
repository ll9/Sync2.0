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
using AutoMapper;
using Sync2._0.AutoMapper.Profiles;
using Sync2._0.DTOs;

namespace Sync2._0.Services
{
    public class SyncService
    {
        private RestClient _client;
        private readonly DbTableRepository _dbTableRepository;
        private readonly IMapper _mapper;

        public SyncService(DbTableRepository dbTableRepository)
        {
            _client = new RestClient("https://localhost:44305/");
            _dbTableRepository = dbTableRepository;
            _mapper = new Mapper(new MapperConfiguration(config => config.AddProfile(new MappingProfile())));
        }

        public void Sync(IEnumerable<DynamicEntity> syncEntities)
        {
            SyncSchema();
            SyncEntities(syncEntities);
        }

        private void SyncEntities(IEnumerable<DynamicEntity> syncEntities)
        {
            var maxSync = syncEntities
                .Select(s => s.RowVersion)
                .DefaultIfEmpty(0)
                .Max();


            var changedData = syncEntities
                .Where(s => s.SyncStatus == false);
            var changeDtos = _mapper.Map<ICollection<DynamicEntityDTO>>(changedData);

            var request = new RestRequest("api/DynamicEntities/{maxSync}", Method.POST);
            request.JsonSerializer = new Serializers.JsonSerializer();
            request.AddUrlSegment("maxSync", maxSync);
            request.AddJsonBody(changeDtos);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                var pulledDtos = JsonConvert.DeserializeObject<List<DynamicEntity>>(response.Content);
                var pulledData = _mapper.Map<ICollection<DynamicEntity>>(pulledDtos);
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
            var changedDtos = _mapper.Map<ICollection<SchemaDefinitionDTO>>(changes);
            var maxSync = GetMaxSync();

            var request = new RestRequest("api/SchemaDefinitions/{maxSync}", Method.POST);
            request.JsonSerializer = new Serializers.JsonSerializer();
            request.AddUrlSegment("maxSync", maxSync);
            request.AddJsonBody(changedDtos);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                var pulledDtos = JsonConvert.DeserializeObject<List<SchemaDefinitionDTO>>(response.Content);
                var pulledData = _mapper.Map<ICollection<SchemaDefinition>>(pulledDtos);
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
