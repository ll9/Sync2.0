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

        private void LoadGrids()
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

            _efContext.SaveChanges();
        }
    }
}
