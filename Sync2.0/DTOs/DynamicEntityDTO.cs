using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.DTOs
{
    public class DynamicEntityDTO
    {
        public string Id { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public bool IsDeleted { get; set; }
        public int RowVersion { get; set; }

        public string ProjectTableName { get; set; }
        public string ProjectId { get; set; }
    }
}
