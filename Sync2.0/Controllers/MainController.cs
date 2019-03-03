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
        private ProjectTableChangeSetRepository _projectTableChangeSetRepository;
        private ProjectTableRepository _projectTableRepository;

        public MainController(MainDialog mainDialog)
        {
            _view = mainDialog;
            _adoContext = new AdoContext();
            _dbTableRepository = new DbTableRepository(_adoContext);
            _efContext = new ApplicationDbContext();
            _projectTableChangeSetRepository = new ProjectTableChangeSetRepository(_efContext);
            _projectTableRepository = new ProjectTableRepository(_efContext);

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
            _efContext.ProjectTables.Add(new ProjectTable(name, columns));
            _efContext.ProjectTableChangeSets.Add(new ProjectTableChangeSet(name, columns));

            _efContext.SaveChanges();
        }

        internal void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            _dbTableRepository.AddColumn(tableName, columnName, columnDataType);
            _projectTableChangeSetRepository.AddColumn(tableName, columnName, columnDataType);
            _projectTableRepository.AddColumn(tableName, columnName, columnDataType);
        }

        internal void DropColumn(string tableName, string columnName)
        {
            _dbTableRepository.DropColumn(tableName, columnName);
            _projectTableChangeSetRepository.DropColumn(tableName, columnName);
            _projectTableRepository.DropColumn(tableName, columnName);
        }
    }
}
