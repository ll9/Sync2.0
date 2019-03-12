using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    public class SyncEntity
    {
        public bool SyncStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int RowVersion { get; set; }
    }
}
