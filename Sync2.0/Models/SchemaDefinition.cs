using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public string Id { get; set; }
        public Dictionary<string, Column> Columns { get; set; }

        public ProjectTable ProjectTable { get; set; }
        public string ProjectTableName { get; set; }
    }
}
