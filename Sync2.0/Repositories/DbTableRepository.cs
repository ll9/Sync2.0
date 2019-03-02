using Sync2._0.Data;
using Sync2._0.Extensions;
using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Repositories
{
    public class DbTableRepository
    {
        private readonly AdoContext _context;

        public DbTableRepository(AdoContext context)
        {
            _context = context;
        }

        internal void AddTable(string name, IEnumerable<Column> columns)
        {
            var columnQuery = string.Join(", ",
                new[] {
                    $"{nameof(SyncEntity.Id)} TEXT DEFAULT (HEX(RANDOMBLOB(16))) PRIMARY KEY",
                    $"{nameof(SyncEntity.SyncStatus)} BOOLEAN",
                    $"{nameof(SyncEntity.IsDeleted)} BOOLEAN",
                    $"{nameof(SyncEntity.RowVersion)} INTEGER"
                }.Concat(
                    columns.Select(c => $"{c.Name} {c.DataType.GetSqlType()}")
                    )
             );
            var addTableQuery = $"CREATE TABLE {name}({columnQuery})";

            _context.ExecuteQuery(addTableQuery);
        }
    }
}
