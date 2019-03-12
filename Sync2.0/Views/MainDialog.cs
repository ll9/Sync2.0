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
            dataGrid.DefaultValuesNeeded += DataGrid_DefaultValuesNeeded;
            dataGrid.CellEndEdit += DataGrid_CellEndEdit;

            tabPage.Controls.Add(dataGrid);
            GridTabControl.TabPages.Add(tabPage);
        }

        private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = sender as DataGridView;

            if (dataGrid.Columns.Contains(nameof(DynamicEntity.SyncStatus)))
            {
                dataGrid.Rows[e.RowIndex].Cells[nameof(DynamicEntity.SyncStatus)].Value = false;
            }
        }

        private void DataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var dataGrid = sender as DataGridView;

            if (dataGrid.Columns.Contains(nameof(DynamicEntity.Id)))
            {
                e.Row.Cells[nameof(DynamicEntity.Id)].Value = Guid.NewGuid().ToString();
            }
            if (dataGrid.Columns.Contains(nameof(DynamicEntity.SyncStatus)))
            {
                e.Row.Cells[nameof(DynamicEntity.SyncStatus)].Value = false;
            }
            if (dataGrid.Columns.Contains(nameof(DynamicEntity.IsDeleted)))
            {
                e.Row.Cells[nameof(DynamicEntity.IsDeleted)].Value = false;
            }
            if (dataGrid.Columns.Contains(nameof(DynamicEntity.RowVersion)))
            {
                e.Row.Cells[nameof(DynamicEntity.RowVersion)].Value = 0;
            }
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

        private void AddColumnMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem menuItem)
            {
                if (menuItem.Owner is ContextMenuStrip owner)
                {
                    if (owner.SourceControl is DataGridView dataGrid)
                    {
                        if (dataGrid.DataSource is DataTable dataTable)
                        {
                            var dialog = new AddColumnDialog();
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                _controller.AddColumn(dataTable.TableName, dialog.ColumnViewModel.Name, dialog.ColumnViewModel.DataType);
                            }
                        }
                    }
                }
            }
        }

        private void DropColumnMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem menuItem)
            {
                if (menuItem.Owner is ContextMenuStrip owner)
                {
                    if (owner.SourceControl is DataGridView dataGrid)
                    {
                        if (dataGrid.DataSource is DataTable dataTable)
                        {
                            _controller.DropColumn(dataTable.TableName, _contextMenuClickedColumnHeader);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            GridTabControl.Controls.Clear();
            _controller.LoadGrids();
        }

        private void schemadefinitionHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GridTabControl.SelectedTab.Controls[0] is DataGridView dataGridView)
            {
                if (dataGridView.DataSource is DataTable dataTable)
                {
                    _controller.HandleSchemaDefinition(dataTable);
                }
            }
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            var dataTables = new List<DataTable>();
            foreach (TabPage tabPage in GridTabControl.TabPages)
            {
                if (tabPage.Controls.Cast<Control>().FirstOrDefault() is DataGridView dataGridView)
                {
                    if (dataGridView.DataSource is DataTable dataTable)
                    {
                        dataTables.Add(dataTable);
                    }
                }
            }
            _controller.Sync(dataTables);
        }

        private void MainDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tabPage in GridTabControl.TabPages)
            {
                if (tabPage.Controls.Cast<Control>().FirstOrDefault() is DataGridView dataGridView)
                {
                    if (dataGridView.DataSource is DataTable dataTable)
                    {
                        _controller.SaveChanges(dataTable);
                    }
                }
            }
        }
    }
}
