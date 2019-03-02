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
    public partial class AddTableDialog : Form
    {
        private class NameComboBoxItem
        {
            public NameComboBoxItem(string display, Type value)
            {
                Display = display;
                Value = value;
            }

            public string Display { get; set; }
            public Type Value { get; set; }
        }

        public AddTableDialog()
        {
            InitializeComponent();
            Initialize();
        }

        public AddTableViewModel AddTableViewModel { get; private set; }

        private void Initialize()
        {
            AddTableViewModel = new AddTableViewModel();
            addTableViewModelBindingSource.DataSource = new AddTableViewModel();
            dataTypeDataGridViewComboBoxColumn.DataSource = new List<NameComboBoxItem>
            {
                new NameComboBoxItem("Text", typeof(string)),
                new NameComboBoxItem("Zahl", typeof(double)),
                new NameComboBoxItem("Datum", typeof(DateTime))
            };
            dataTypeDataGridViewComboBoxColumn.DisplayMember = nameof(NameComboBoxItem.Display);
            dataTypeDataGridViewComboBoxColumn.ValueMember = nameof(NameComboBoxItem.Value);

            columnViewModelsDataGridView.DefaultValuesNeeded += (s, e) => e.Row.Cells[dataTypeDataGridViewComboBoxColumn.Name].Value = typeof(string);
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
