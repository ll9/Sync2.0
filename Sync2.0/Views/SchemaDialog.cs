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
    public partial class SchemaDialog : Form
    {
        public SchemaDialog(SchemaViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            schemaViewModelBindingSource.DataSource = ViewModel;
        }

        public SchemaViewModel ViewModel { get; }

        private void ToErfassenButton_Click(object sender, EventArgs e)
        {
            var selectedItems = NichtErfassenListBox.SelectedItems.Cast<DataColumn>().ToList();

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                ViewModel.Erfassen.Add(selectedItems[i]);
                ViewModel.NicthErfassen.Remove(selectedItems[i]);
            }
        }

        private void ToNichtErfassenButton_Click(object sender, EventArgs e)
        {
            var selectedItems = ErfassenListBox.SelectedItems.Cast<DataColumn>().ToList();

            for (int i = selectedItems.Count - 1; i >= 0; i--)
            {
                ViewModel.NicthErfassen.Add(selectedItems[i]);
                ViewModel.Erfassen.Remove(selectedItems[i]);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
