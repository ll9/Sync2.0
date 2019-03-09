namespace Sync2._0
{
    partial class MainDialog
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GridTabControl = new System.Windows.Forms.TabControl();
            this.AddTableButton = new System.Windows.Forms.Button();
            this.ColumnMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddColumnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DropColumnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schemadefinitionHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.ColumnMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridTabControl
            // 
            this.GridTabControl.Location = new System.Drawing.Point(24, 13);
            this.GridTabControl.Name = "GridTabControl";
            this.GridTabControl.SelectedIndex = 0;
            this.GridTabControl.Size = new System.Drawing.Size(788, 382);
            this.GridTabControl.TabIndex = 0;
            // 
            // AddTableButton
            // 
            this.AddTableButton.Location = new System.Drawing.Point(831, 13);
            this.AddTableButton.Name = "AddTableButton";
            this.AddTableButton.Size = new System.Drawing.Size(75, 23);
            this.AddTableButton.TabIndex = 1;
            this.AddTableButton.Text = "Add Table";
            this.AddTableButton.UseVisualStyleBackColor = true;
            this.AddTableButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // ColumnMenuStrip
            // 
            this.ColumnMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddColumnMenuItem,
            this.DropColumnMenuItem,
            this.schemadefinitionHinzufügenToolStripMenuItem});
            this.ColumnMenuStrip.Name = "contextMenuStrip1";
            this.ColumnMenuStrip.Size = new System.Drawing.Size(231, 70);
            // 
            // AddColumnMenuItem
            // 
            this.AddColumnMenuItem.Name = "AddColumnMenuItem";
            this.AddColumnMenuItem.Size = new System.Drawing.Size(230, 22);
            this.AddColumnMenuItem.Text = "Spalte hinzufügen";
            this.AddColumnMenuItem.Click += new System.EventHandler(this.AddColumnMenuItem_Click);
            // 
            // DropColumnMenuItem
            // 
            this.DropColumnMenuItem.Name = "DropColumnMenuItem";
            this.DropColumnMenuItem.Size = new System.Drawing.Size(230, 22);
            this.DropColumnMenuItem.Text = "Spalte löschen";
            this.DropColumnMenuItem.Click += new System.EventHandler(this.DropColumnMenuItem_Click);
            // 
            // schemadefinitionHinzufügenToolStripMenuItem
            // 
            this.schemadefinitionHinzufügenToolStripMenuItem.Name = "schemadefinitionHinzufügenToolStripMenuItem";
            this.schemadefinitionHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.schemadefinitionHinzufügenToolStripMenuItem.Text = "Schemadefinition hinzufügen";
            this.schemadefinitionHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.schemadefinitionHinzufügenToolStripMenuItem_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(831, 59);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.Location = new System.Drawing.Point(831, 105);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(75, 23);
            this.SyncButton.TabIndex = 3;
            this.SyncButton.Text = "Sync";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 428);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.AddTableButton);
            this.Controls.Add(this.GridTabControl);
            this.Name = "MainDialog";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDialog_FormClosing);
            this.ColumnMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl GridTabControl;
        private System.Windows.Forms.Button AddTableButton;
        private System.Windows.Forms.ContextMenuStrip ColumnMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddColumnMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DropColumnMenuItem;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ToolStripMenuItem schemadefinitionHinzufügenToolStripMenuItem;
        private System.Windows.Forms.Button SyncButton;
    }
}

