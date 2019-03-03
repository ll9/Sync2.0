using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    public class ProjectTableChangeSet
    {
        public ProjectTableChangeSet()
        {

        }

        public ProjectTableChangeSet(string name, IEnumerable<Column> columns)
        {
            Name = name;
            SetJson(columns);
        }

        [Key]
        public string Name { get; set; }
        public bool SyncStatus { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int RowVersion { get; set; } = 0;
        public string Json { get; set; }

        public void SetJson(IEnumerable<Column> columns)
        {
            var colDict = columns.ToDictionary(c => c.Name);
            Json = JsonConvert.SerializeObject(colDict);
        }

        public void GetJsonDictionary()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Column>>(Json);
        }
    }
}
