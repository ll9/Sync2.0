namespace Sync2._0.Views
{
    partial class SchemaDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ToErfassenButton = new System.Windows.Forms.Button();
            this.ToNichtErfassenButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NichtErfassenListBox = new System.Windows.Forms.ListBox();
            this.nicthErfassenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schemaViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ErfassenListBox = new System.Windows.Forms.ListBox();
            this.erfassenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nicthErfassenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemaViewModelBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erfassenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ToErfassenButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ToNichtErfassenButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 278);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ToErfassenButton
            // 
            this.ToErfassenButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ToErfassenButton.Location = new System.Drawing.Point(292, 113);
            this.ToErfassenButton.Name = "ToErfassenButton";
            this.ToErfassenButton.Size = new System.Drawing.Size(52, 23);
            this.ToErfassenButton.TabIndex = 1;
            this.ToErfassenButton.Text = ">";
            this.ToErfassenButton.UseVisualStyleBackColor = true;
            this.ToErfassenButton.Click += new System.EventHandler(this.ToErfassenButton_Click);
            // 
            // ToNichtErfassenButton
            // 
            this.ToNichtErfassenButton.Location = new System.Drawing.Point(292, 142);
            this.ToNichtErfassenButton.Name = "ToNichtErfassenButton";
            this.ToNichtErfassenButton.Size = new System.Drawing.Size(52, 23);
            this.ToNichtErfassenButton.TabIndex = 2;
            this.ToNichtErfassenButton.Text = "<";
            this.ToNichtErfassenButton.UseVisualStyleBackColor = true;
            this.ToNichtErfassenButton.Click += new System.EventHandler(this.ToNichtErfassenButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NichtErfassenListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(278, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nicht Erfassen";
            // 
            // NichtErfassenListBox
            // 
            this.NichtErfassenListBox.DataSource = this.nicthErfassenBindingSource;
            this.NichtErfassenListBox.DisplayMember = "ColumnName";
            this.NichtErfassenListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NichtErfassenListBox.FormattingEnabled = true;
            this.NichtErfassenListBox.Location = new System.Drawing.Point(3, 16);
            this.NichtErfassenListBox.Name = "NichtErfassenListBox";
            this.NichtErfassenListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.NichtErfassenListBox.Size = new System.Drawing.Size(272, 243);
            this.NichtErfassenListBox.TabIndex = 0;
            // 
            // nicthErfassenBindingSource
            // 
            this.nicthErfassenBindingSource.DataMember = "NicthErfassen";
            this.nicthErfassenBindingSource.DataSource = this.schemaViewModelBindingSource;
            // 
            // schemaViewModelBindingSource
            // 
            this.schemaViewModelBindingSource.DataSource = typeof(Sync2._0.ViewModels.SchemaViewModel);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ErfassenListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(350, 8);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox2, 2);
            this.groupBox2.Size = new System.Drawing.Size(278, 262);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Erfassen";
            // 
            // ErfassenListBox
            // 
            this.ErfassenListBox.DataSource = this.erfassenBindingSource;
            this.ErfassenListBox.DisplayMember = "ColumnName";
            this.ErfassenListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErfassenListBox.FormattingEnabled = true;
            this.ErfassenListBox.Location = new System.Drawing.Point(3, 16);
            this.ErfassenListBox.Name = "ErfassenListBox";
            this.ErfassenListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ErfassenListBox.Size = new System.Drawing.Size(272, 243);
            this.ErfassenListBox.TabIndex = 0;
            // 
            // erfassenBindingSource
            // 
            this.erfassenBindingSource.DataMember = "Erfassen";
            this.erfassenBindingSource.DataSource = this.schemaViewModelBindingSource;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(471, 311);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(562, 311);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Abbrechen";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SchemaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 356);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SchemaDialog";
            this.Text = "SchemaDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nicthErfassenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemaViewModelBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erfassenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ToErfassenButton;
        private System.Windows.Forms.Button ToNichtErfassenButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox NichtErfassenListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox ErfassenListBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.BindingSource nicthErfassenBindingSource;
        private System.Windows.Forms.BindingSource schemaViewModelBindingSource;
        private System.Windows.Forms.BindingSource erfassenBindingSource;
    }
}