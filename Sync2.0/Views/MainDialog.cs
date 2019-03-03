﻿using Sync2._0.Controllers;
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
        private string _contextMenuClickedColumnHeader;

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

        internal void AddGrid(DataTable table)
        {
            var tabPage = new TabPage(table.TableName);
            var dataGrid = new DataGridView
            {
                DataSource = table,
                Dock = DockStyle.Fill
            };
            dataGrid.ColumnHeaderMouseClick += DataGrid_ColumnHeaderMouseClick;

            tabPage.Controls.Add(dataGrid);
            GridTabControl.TabPages.Add(tabPage);
        }

        private void DataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender is DataGridView dataGrid)
            {
                var hitTest = dataGrid.HitTest(e.X, e.Y);

                if (e.Button == MouseButtons.Right)
                {
                    if (hitTest.RowIndex == -1)
                    {
                        _contextMenuClickedColumnHeader = dataGrid.Columns[e.ColumnIndex].HeaderText;
                        ColumnMenuStrip.Show(dataGrid, dataGrid.PointToClient(Cursor.Position));
                    }
                }
            }
        }
    }
}
