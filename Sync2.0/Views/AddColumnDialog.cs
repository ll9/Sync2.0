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
    public partial class AddColumnDialog : Form
    {
        public ColumnViewModel ColumnViewModel { get; set; }

        public AddColumnDialog()
        {
            InitializeComponent();

            ColumnViewModel = new ColumnViewModel { DataType = typeof(string) };
            columnViewModelBindingSource.DataSource = ColumnViewModel;
            dataTypeComboBox.DataSource = new List<ComboBoxItem>
            {
                ComboBoxItem.TextComboBoxItem,
                ComboBoxItem.ZahlComboBoxItem,
                ComboBoxItem.DatumComboBoxItem
            };
            dataTypeComboBox.DisplayMember = nameof(ComboBoxItem.Display);
            dataTypeComboBox.ValueMember = nameof(ComboBoxItem.Value);
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
