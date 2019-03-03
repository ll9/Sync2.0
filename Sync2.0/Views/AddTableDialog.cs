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
                public AddTableDialog()
        {
            InitializeComponent();
            Initialize();
        }

        public AddTableViewModel AddTableViewModel { get; private set; }

        private void Initialize()
        {
            AddTableViewModel = new AddTableViewModel();
            addTableViewModelBindingSource.DataSource = AddTableViewModel;
            dataTypeComboBoxColumn.DataSource = new List<ComboBoxItem>
            {
                ComboBoxItem.TextComboBoxItem,
                ComboBoxItem.ZahlComboBoxItem,
                ComboBoxItem.DatumComboBoxItem
            };
            dataTypeComboBoxColumn.DisplayMember = nameof(ComboBoxItem.Display);
            dataTypeComboBoxColumn.ValueMember = nameof(ComboBoxItem.Value);

            columnViewModelsDataGridView.DefaultValuesNeeded += (s, e) => e.Row.Cells[dataTypeComboBoxColumn.Name].Value = ComboBoxItem.TextComboBoxItem.Value;
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
