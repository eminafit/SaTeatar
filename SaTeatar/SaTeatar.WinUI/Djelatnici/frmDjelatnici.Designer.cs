
namespace SaTeatar.WinUI.Djelatnici
{
    partial class frmDjelatnici
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
            this.cmbDjelatnici = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDjelatnici = new System.Windows.Forms.DataGridView();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDjelatnici)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDjelatnici
            // 
            this.cmbDjelatnici.FormattingEnabled = true;
            this.cmbDjelatnici.Location = new System.Drawing.Point(154, 33);
            this.cmbDjelatnici.Name = "cmbDjelatnici";
            this.cmbDjelatnici.Size = new System.Drawing.Size(295, 24);
            this.cmbDjelatnici.TabIndex = 0;
            this.cmbDjelatnici.SelectedIndexChanged += new System.EventHandler(this.cmbDjelatnici_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vrsta djelatnika:";
            // 
            // dgvDjelatnici
            // 
            this.dgvDjelatnici.AllowUserToAddRows = false;
            this.dgvDjelatnici.AllowUserToDeleteRows = false;
            this.dgvDjelatnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDjelatnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImePrezime,
            this.Status});
            this.dgvDjelatnici.Location = new System.Drawing.Point(28, 171);
            this.dgvDjelatnici.Name = "dgvDjelatnici";
            this.dgvDjelatnici.ReadOnly = true;
            this.dgvDjelatnici.RowHeadersWidth = 51;
            this.dgvDjelatnici.RowTemplate.Height = 24;
            this.dgvDjelatnici.Size = new System.Drawing.Size(597, 233);
            this.dgvDjelatnici.TabIndex = 2;
            // 
            // ImePrezime
            // 
            this.ImePrezime.DataPropertyName = "ImePrezime";
            this.ImePrezime.HeaderText = "Ime i prezime";
            this.ImePrezime.MinimumWidth = 6;
            this.ImePrezime.Name = "ImePrezime";
            this.ImePrezime.ReadOnly = true;
            this.ImePrezime.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 125;
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(154, 87);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(295, 22);
            this.txtIme.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ime:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(477, 90);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(106, 54);
            this.btnPretrazi.TabIndex = 5;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(25, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prezime:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(154, 124);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(295, 22);
            this.txtPrezime.TabIndex = 6;
            // 
            // frmDjelatnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.dgvDjelatnici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDjelatnici);
            this.Name = "frmDjelatnici";
            this.Text = "Djelatnici";
            this.Load += new System.EventHandler(this.frmDjelatnici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDjelatnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDjelatnici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDjelatnici;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrezime;
    }
}