using Sync2._0.Controllers;
using Sync2._0.Data;
using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Repositories
{
    public class ProjectTableChangeSetRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectTableChangeSetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            var changeset = _context.ProjectTableChangeSets.SingleOrDefault(p => p.Name == tableName);
            if (changeset == null)
            {
                _context.ProjectTableChangeSets.Add(new ProjectTableChangeSet(tableName, new Column[] { new Column(columnName, columnDataType) }));
            }
            else
            {
                var dict = changeset.JsonDict;
                if (dict.ContainsKey(columnName))
                {
                    if (dict[columnName] == null)
                    {
                        dict[columnName] = new Column(columnName, columnDataType);
                        changeset.JsonDict = dict;
                    }
                    else if (dict[columnName].DataType != columnDataType)
                    {
                        throw new InvalidOperationException("Column already exists with different Datatype");
                    }
                }
                else
                {
                    dict[columnName] = new Column(columnName, columnDataType);
                    changeset.JsonDict = dict;
                }
            }
            _context.SaveChanges();
        }

        public void DropColumn(string tableName, string columnName)
        {

            var changeset = _context.ProjectTableChangeSets.SingleOrDefault(p => p.Name == tableName);
            if (changeset == null)
            {
                throw new InvalidOperationException("Cannot Remove Column from nonexistent table");
            }
            else
            {
                var dict = changeset.JsonDict;
                if (dict.ContainsKey(columnName))
                {
                    dict.Remove(columnName);
                    changeset.JsonDict = dict;
                }
                else
                {
                    dict.Add(columnName, null);
                }
            }
            _context.SaveChanges();
        }
    }
}
