using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sync2._0.Models;

namespace Sync2._0.Controllers
{
    public class MainController
    {
        private MainDialog _mainDialog;

        public MainController(MainDialog mainDialog)
        {
            _mainDialog = mainDialog;
        }

        internal void AddTable(string name, IEnumerable<Column> enumerable)
        {
            throw new NotImplementedException();
        }
    }
}
