using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sync2._0.Data;
using Sync2._0.Facades;
using Sync2._0.Models;
using Sync2._0.Repositories;
using Sync2._0.Services;

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
        private SynchronizationService _syncService;
        private DDLFacade _dllFacade;

        public MainController(MainDialog mainDialog)
        {
            _view = mainDialog;
            _adoContext = new AdoContext();
            _dbTableRepository = new DbTableRepository(_adoContext);
            _efContext = new ApplicationDbContext();
            _projectTableChangeSetRepository = new ProjectTableChangeSetRepository(_efContext);
            _projectTableRepository = new ProjectTableRepository(_efContext);
            _dllFacade = new DDLFacade(_efContext, _dbTableRepository, _projectTableChangeSetRepository, _projectTableRepository);
            _syncService = new SynchronizationService(_efContext, _dllFacade);

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
            _dllFacade.AddTableWithChangeSet(name, columns);
        }

        internal void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            _dllFacade.AddColumn(tableName, columnName, columnDataType);
        }

        internal void DropColumn(string tableName, string columnName)
        {
            _dllFacade.DropColumn(tableName, columnName);
        }

        internal void Sync()
        {
            _syncService.Sync();
        }
    }
}
