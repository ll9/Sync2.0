using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    [NotMapped]
    public class DynamicEntity: SyncEntity
    {
        public DynamicEntity()
        {

        }

        public DynamicEntity(DataRow row, ProjectTable projectTable)
        {
            ProjectTable = projectTable;
            ProjectTableName = projectTable.Name;
            Id = row.Field<string>(nameof(Id));
            SyncStatus = row.Field<bool>(nameof(SyncStatus));
            IsDeleted = row.Field<bool>(nameof(IsDeleted));
            RowVersion = (int)row.Field<long>(nameof(RowVersion));
            Data = row.Table.Columns
              .Cast<DataColumn>()
              .ToDictionary(c => c.ColumnName, c => row[c]);
        }

        public string Id { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public ProjectTable ProjectTable { get; set; }
        public string ProjectTableName { get; set; }

        public static IEnumerable<string> GetSyncEntityNames()
        {
            return new[]
            {
                nameof(Id),
                nameof(SyncStatus),
                nameof(IsDeleted),
                nameof(RowVersion),
                nameof(ProjectTable),
                nameof(ProjectTableName),
            };
        }
    }
}
