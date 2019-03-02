using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sync2._0.Data;
using Sync2._0.Models;
using Sync2._0.Repositories;

namespace Sync2._0.Controllers
{
    public class MainController
    {
        private MainDialog _mainDialog;
        private AdoContext _adoContext;
        private DbTableRepository _dbTableRepository;

        public MainController(MainDialog mainDialog)
        {
            _mainDialog = mainDialog;
            _adoContext = new AdoContext();
            _dbTableRepository = new DbTableRepository(_adoContext);
        }

        internal void AddTable(string name, IEnumerable<Column> columns)
        {
            _dbTableRepository.AddTable(name, columns);
        }
    }
}
