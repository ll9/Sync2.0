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
using Sync2._0.Services;

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
            AddProjectId();
            LoadGrids();
        }

        private void AddProjectId()
        {
            if (!_efContext.Projects.Any())
            {
                _efContext.Projects.Add(new Project { Id = Guid.NewGuid().ToString() });
                _efContext.SaveChanges();
            }
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
            var porjectId = _efContext.Projects.Single().Id;
            _efContext.ProjectTables.Add(new ProjectTable(name, porjectId));

            _efContext.SaveChanges();
        }

        internal void AddColumn(string tableName, string columnName, Type columnDataType)
        {
            _dbTableRepository.AddColumn(tableName, columnName, columnDataType);
        }

        internal void DropColumn(string tableName, string columnName)
        {
            _dbTableRepository.DropColumn(tableName, columnName);
        }

        internal void HandleSchemaDefinition(DataTable dataTable)
        {
            var controller = new SchemaController(dataTable, _efContext);
            var dialog = controller.CreateDialog();
            dialog.ShowDialog();
        }

        internal void Sync(List<DataTable> dataTables)
        {
            var syncEntities = dataTables
                .SelectMany(dt => _dbTableRepository.ListSyncEntities(dt.TableName));
            var syncService = new SyncService(_dbTableRepository);
            syncService.Sync(syncEntities);
        }

        internal void SaveChanges(DataTable dataTable)
        {
            _adoContext.Update(dataTable);
        }
    }
}
