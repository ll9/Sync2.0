using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.ViewModels
{
    public class SchemaViewModel
    {
        public SchemaViewModel(IList<DataColumn> erfassen, IList<DataColumn> nichtErfassen)
        {
            Erfassen = new BindingList<DataColumn>(erfassen);
            NicthErfassen = new BindingList<DataColumn>(nichtErfassen);
        }

        public BindingList<DataColumn> Erfassen { get; set; }
        public BindingList<DataColumn> NicthErfassen { get; set; }
    }
}
