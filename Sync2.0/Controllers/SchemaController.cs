using Microsoft.EntityFrameworkCore;
using Sync2._0.Data;
using Sync2._0.Models;
using Sync2._0.ViewModels;
using Sync2._0.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync2._0.Controllers
{
    public class SchemaController
    {
        private SchemaListDialog _view;
        private DataTable _dataTable;
        private ApplicationDbContext _context;

        public SchemaController(DataTable dataTable, ApplicationDbContext efContext)
        {
            _dataTable = dataTable;
            _context = efContext;
        }

        internal SchemaListDialog CreateDialog()
        {
            var schemas = _context.SchemaDefinitions
                .Include(s => s.ProjectTable)
                .Where(s => s.ProjectTableName == _dataTable.TableName)
                .Where(s => s.IsDeleted == false)
                .ToList();

            var schemaListViewModel = new SchemaListViewModel(schemas);
            _view = new SchemaListDialog(this, schemaListViewModel);
            return _view;
        }

        internal void CreateSchema()
        {
            var _nichtErfassen = _dataTable.Columns.Cast<DataColumn>()
                .Where(c => !DynamicEntity.GetSyncEntityNames().Any(se => se.Equals(c.ColumnName, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var _erfassen = new List<DataColumn>();
            var viewModel = new SchemaViewModel(_erfassen, _nichtErfassen);

            var dialog = new SchemaDialog(viewModel);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var schemaDefinition = new SchemaDefinition
                {
                    Id = Guid.NewGuid().ToString(),
                    ProjectTableName = _dataTable.TableName,
                    Columns = viewModel.Erfassen
                        .Select(c => new Column(c.ColumnName, c.DataType))
                        .ToDictionary(c => c.Name)
                };

                _view.SchemaListViewModel.SchemaDefinitions.Add(schemaDefinition);
                _context.SchemaDefinitions.Add(schemaDefinition);
                _context.SaveChanges();
            }
        }

        internal void EditSchema(SchemaDefinition selectedItem)
        {
            var _erfassen = selectedItem.Columns.Values
                .Select(c => new DataColumn(c.Name, c.DataType))
                .ToList();

            var _nichtErfassen = _dataTable.Columns.Cast<DataColumn>()
                .Where(c => !DynamicEntity.GetSyncEntityNames().Any(se => se.Equals(c.ColumnName, StringComparison.OrdinalIgnoreCase)))
                .Where(c => !_erfassen.Any(erf => erf.ColumnName.Equals(c.ColumnName, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var viewModel = new SchemaViewModel(_erfassen, _nichtErfassen);

            var dialog = new SchemaDialog(viewModel);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedItem.Columns = dialog.ViewModel.Erfassen
                    .Select(c => new Column(c.ColumnName, c.DataType))
                    .ToDictionary(c => c.Name);

                _context.SchemaDefinitions.Update(selectedItem);
                _context.SaveChanges();
            }
        }

        internal void DropSchema(IList<SchemaDefinition> selectedItems)
        {
            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                selectedItems[i].IsDeleted = true;
                selectedItems[i].SyncStatus = false;
                _context.Entry(selectedItems[i]).State = EntityState.Modified;
                _context.SaveChanges();
                _view.SchemaListViewModel.SchemaDefinitions.Remove(selectedItems[i]);
            }
            _context.SaveChanges();
        }
    }
}
