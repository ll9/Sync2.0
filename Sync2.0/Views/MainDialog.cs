using Sync2._0.Controllers;
using Sync2._0.Models;
using Sync2._0.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync2._0
{
    public partial class MainDialog : Form
    {
        private MainController _controller;

        public MainDialog()
        {
            InitializeComponent();
            _controller = new MainController(this);
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            var dialog = new AddTableDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _controller.AddTable(
                    dialog.AddTableViewModel.Name,
                    dialog.AddTableViewModel.ColumnViewModels.Select(c => new Column(c.Name, c.DataType))
                    );
            }
        }
    }
}
