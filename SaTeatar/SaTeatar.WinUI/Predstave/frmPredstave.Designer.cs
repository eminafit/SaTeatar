
namespace SaTeatar.WinUI.Predstave
{
    partial class frmPredstave
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
            this.dgvPredstave = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoviPredstave = new System.Windows.Forms.ComboBox();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PredstavaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPredstave)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPredstave
            // 
            this.dgvPredstave.AllowUserToAddRows = false;
            this.dgvPredstave.AllowUserToDeleteRows = false;
            this.dgvPredstave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPredstave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.PredstavaId,
            this.Status});
            this.dgvPredstave.Location = new System.Drawing.Point(29, 136);
            this.dgvPredstave.Name = "dgvPredstave";
            this.dgvPredstave.ReadOnly = true;
            this.dgvPredstave.RowHeadersWidth = 51;
            this.dgvPredstave.RowTemplate.Height = 24;
            this.dgvPredstave.Size = new System.Drawing.Size(726, 279);
            this.dgvPredstave.TabIndex = 0;
            this.dgvPredstave.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPredstave_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tip predstave: ";
            // 
            // cmbTipoviPredstave
            // 
            this.cmbTipoviPredstave.FormattingEnabled = true;
            this.cmbTipoviPredstave.Location = new System.Drawing.Point(150, 41);
            this.cmbTipoviPredstave.Name = "cmbTipoviPredstave";
            this.cmbTipoviPredstave.Size = new System.Drawing.Size(284, 24);
            this.cmbTipoviPredstave.TabIndex = 2;
            this.cmbTipoviPredstave.SelectedIndexChanged += new System.EventHandler(this.cmbTipoviPredstave_SelectedIndexChanged);
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 125;
            // 
            // PredstavaId
            // 
            this.PredstavaId.DataPropertyName = "PredstavaId";
            this.PredstavaId.HeaderText = "PredstavaId";
            this.PredstavaId.MinimumWidth = 6;
            this.PredstavaId.Name = "PredstavaId";
            this.PredstavaId.ReadOnly = true;
            this.PredstavaId.Visible = false;
            this.PredstavaId.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Aktivna";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 125;
            // 
            // frmPredstave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTipoviPredstave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPredstave);
            this.Name = "frmPredstave";
            this.Text = "Predstave";
            this.Load += new System.EventHandler(this.frmPredstave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPredstave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPredstave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoviPredstave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PredstavaId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
    }
}