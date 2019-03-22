using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    public class SchemaDefinition: SyncEntity
    {
        public SchemaDefinition()
        {
            SyncStatus = false;
            IsDeleted = false;
            RowVersion = 0;
        }

        public SchemaDefinition(string id, Dictionary<string, Column> columns, ProjectTable projectTable, string projectTableName)
        {
            Id = id;
            Columns = columns;
            ProjectTable = projectTable;
            ProjectTableName = projectTableName;
        }

        [Key]
        public string Id { get; set; }
        public Dictionary<string, Column> Columns { get; set; }

        public ProjectTable ProjectTable { get; set; }
        public string ProjectTableName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string TableNameWIthId => $"{ProjectTableName} ({Id})";
    }
}
