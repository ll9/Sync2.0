﻿using Sync2._0.Data;
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
    public class SqlColumn
    {
        public SqlColumn(string name, string type, bool notNull, string @default, bool isPrimaryKey)
        {
            Name = name;
            Type = type;
            NotNull = notNull;
            Default = @default;
            IsPrimaryKey = isPrimaryKey;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public bool NotNull { get; set; }
        public string Default { get; set; }
        public bool IsPrimaryKey { get; set; }

        public string GetSqlString()
        {
            return $"{Name} {Type} {(string.IsNullOrEmpty(Default) ? "" : $"DEFAULT ({Default})")} {(IsPrimaryKey ? "PRIMARY KEY" : "")} {(NotNull ? "NOT NULL" : "")}";
        }

        public Type GetCSharpType()
        {
            if (Type == "INTEGER")
            {
                return typeof(int);
            }
            else if (Type == "DOUBLE")
            {
                return typeof(double);
            }
            else if (Type == "BOOLEAN")
            {
                return typeof(bool);
            }
            else if (Type == "DATETIME")
            {
                return typeof(DateTime);
            }
            else
            {
                return typeof(string);
            }
        }
    }

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

        public ICollection<SqlColumn> GetColumns(string tableName)
        {
            var columns = new List<SqlColumn>();
            var query = $"PRAGMA table_info('{tableName}')";

            using (var connection = _context.GetConnection())
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    columns.Add(new SqlColumn(
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetBoolean(3),
                        (reader[4] == DBNull.Value ? null : reader.GetString(4)),
                        reader.GetBoolean(5)));
                }
            }
            return columns;
        }

        internal void DropColumn(string tableName, string columnName)
        {
            var tempTable = $"_{tableName}";
            var columns = GetColumns(tableName).Where(c => c.Name != columnName);
            var columnsString = string.Join(", ", columns.Select(c => c.GetSqlString()));

            var renameQuery = $"ALTER TABLE {tableName} RENAME TO {tempTable}";
            var createQuery = $"CREATE TABLE {tableName}({columnsString})";
            var insertQuery = $"INSERT INTO {tableName} SELECT {string.Join(", ", columns.Select(c => c.Name))} FROM {tempTable}";
            var dropQuery = $"DROP TABLE {tempTable}";

            _context.ExecuteQuery(renameQuery);
            _context.ExecuteQuery(createQuery);
            _context.ExecuteQuery(insertQuery);
            _context.ExecuteQuery(dropQuery);
        }
    }
}
