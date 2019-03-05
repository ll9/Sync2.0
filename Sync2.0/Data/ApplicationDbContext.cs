using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTable> ProjectTables { get; set; }
        public DbSet<SchemaDefinition> SchemaDefinitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.AppSettings["ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchemaDefinitionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class SchemaDefinitionConfiguration : IEntityTypeConfiguration<SchemaDefinition>
    {
        public void Configure(EntityTypeBuilder<SchemaDefinition> builder)
        {
            // This Converter will perform the conversion to and from Json to the desired type
            builder.Property(e => e.Columns).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<Dictionary<string, Column>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
