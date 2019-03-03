namespace Sync2._0.Views
{
    partial class AddColumnDialog
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label DataTypeLabel;
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.dataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.columnViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            nameLabel = new System.Windows.Forms.Label();
            DataTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.columnViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.columnViewModelBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(83, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // DataTypeLabel
            // 
            DataTypeLabel.AutoSize = true;
            DataTypeLabel.Location = new System.Drawing.Point(12, 44);
            DataTypeLabel.Name = "DataTypeLabel";
            DataTypeLabel.Size = new System.Drawing.Size(53, 13);
            DataTypeLabel.TabIndex = 3;
            DataTypeLabel.Text = "Datentyp:";
            // 
            // dataTypeComboBox
            // 
            this.dataTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.columnViewModelBindingSource, "DataType", true));
            this.dataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataTypeComboBox.FormattingEnabled = true;
            this.dataTypeComboBox.Location = new System.Drawing.Point(83, 41);
            this.dataTypeComboBox.Name = "dataTypeComboBox";
            this.dataTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.dataTypeComboBox.TabIndex = 4;
            // 
            // OkButton
            // 
            this.OkButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.columnViewModelBindingSource, "IsValid", true));
            this.OkButton.Location = new System.Drawing.Point(36, 84);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(129, 84);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Abbrechen";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // columnViewModelBindingSource
            // 
            this.columnViewModelBindingSource.DataSource = typeof(Sync2._0.ViewModels.ColumnViewModel);
            // 
            // AddColumnDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 129);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.dataTypeComboBox);
            this.Controls.Add(DataTypeLabel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Name = "AddColumnDialog";
            this.Text = "AddColumnDialog";
            ((System.ComponentModel.ISupportInitialize)(this.columnViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource columnViewModelBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox dataTypeComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}