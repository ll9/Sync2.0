using Sync2._0.Controllers;
using Sync2._0.Models;
using Sync2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync2._0.Views
{
    public partial class SchemaListDialog : Form
    {
        private readonly SchemaController _controller;

        public SchemaListDialog(SchemaController schemaController, SchemaListViewModel schemaListViewModel)
        {
            InitializeComponent();
            _controller = schemaController;
            SchemaListViewModel = schemaListViewModel;

            schemaDefinitionsBindingSource.DataSource = schemaListViewModel;
        }

        public SchemaListViewModel SchemaListViewModel { get; }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _controller.CreateSchema();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var selectedSchema = SchemaListBox.SelectedItem as SchemaDefinition;

            if (selectedSchema != null)
            {
            _controller.EditSchema(selectedSchema);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedSchema = SchemaListBox.SelectedItems.Cast<SchemaDefinition>().ToList();
            _controller.DropSchema(selectedSchema);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
