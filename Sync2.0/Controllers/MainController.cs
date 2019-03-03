using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sync2._0.Data;
using Sync2._0.Models;
using Sync2._0.Repositories;

namespace Sync2._0.Controllers
{
    public class MainController
    {
        private MainDialog _view;
        private AdoContext _adoContext;
        private DbTableRepository _dbTableRepository;
        private ApplicationDbContext _efContext;

        public MainController(MainDialog mainDialog)
        {
            _view = mainDialog;
            _adoContext = new AdoContext();
            _dbTableRepository = new DbTableRepository(_adoContext);
            _efContext = new ApplicationDbContext();

            _efContext.Database.Migrate();
            LoadGrids();
        }

        public void LoadGrids()
        {
            foreach (var projectTable in _efContext.ProjectTables)
            {
                DataTable table = _dbTableRepository.List(projectTable.Name);
                _view.AddGrid(table);
            }
        }

        internal void AddTable(string name, IEnumerable<Column> columns)
        {
            _dbTableRepository.AddTable(name, columns);
            _efContext.ProjectTables.Add(new ProjectTable(name));
            _efContext.ProjectTableChangeSets.Add(new ProjectTableChangeSet(name, columns));

            _efContext.SaveChanges();
        }

        internal void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            _dbTableRepository.AddColumn(tableName, columnName, columnDataType);

            var changeset = _efContext.ProjectTableChangeSets.SingleOrDefault(p => p.Name == tableName);
            if (changeset == null)
            {
                throw new InvalidOperationException("Cannot Add Column to nonexistent table");
            }
            else
            {
                var dict = changeset.JsonDict;
                if (dict.ContainsKey(columnName))
                {
                    if (dict[columnName].DataType != columnDataType)
                    {
                        throw new InvalidOperationException("Column already exists with different Datatype");
                    }
                }
                else
                {
                    dict[columnName] = new Column(columnName, columnDataType);
                    changeset.JsonDict = dict;
                    changeset.SyncStatus = false;
                }
            }
        }

        internal void DropColumn(string tableName, string columnName)
        {
            _dbTableRepository.DropColumn(tableName, columnName);
        }
    }
}
