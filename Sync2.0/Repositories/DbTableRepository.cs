using Sync2._0.Data;
using Sync2._0.Extensions;
using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

        internal DataTable List(string tableName)
        {
            var query = $"SELECT * FROM {tableName}";

            using (var connection = _context.GetConnection())
            using (var adapter = new SQLiteDataAdapter(query, connection))
            {
                var table = new DataTable(tableName);
                adapter.Fill(table);
                return table;
            }
        }

        internal void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            var query = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDataType.GetSqlType()}";

            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
