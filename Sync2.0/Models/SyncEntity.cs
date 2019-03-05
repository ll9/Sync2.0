using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    class SyncEntity
    {
        public string Id { get; set; }
        public bool SyncStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int RowVersion { get; set; }
        public string Json { get; set; }

        public static IEnumerable<string> GetSyncEntityNames()
        {
            return new[]
            {
                nameof(Id),
                nameof(SyncStatus),
                nameof(IsDeleted),
                nameof(RowVersion),
            };
        }
    }
}
