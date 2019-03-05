using Sync2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.ViewModels
{
    public class SchemaListViewModel
    {
        public SchemaListViewModel(IList<SchemaDefinition> schemaDefinitions)
        {
            SchemaDefinitions = new BindingList<SchemaDefinition>(schemaDefinitions);
        }

        public BindingList<SchemaDefinition> SchemaDefinitions { get; set; }
    }
}
