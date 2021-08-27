
namespace SaTeatar.WinUI.Izvodjenja
{
    partial class frmIzvodjenja
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
            this.dgvIzvodjenja = new System.Windows.Forms.DataGridView();
            this.dtpDatumOD = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumDO = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.Predstava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pozoriste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvodjenja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIzvodjenja
            // 
            this.dgvIzvodjenja.AllowUserToAddRows = false;
            this.dgvIzvodjenja.AllowUserToDeleteRows = false;
            this.dgvIzvodjenja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvodjenja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Predstava,
            this.Pozoriste,
            this.DatumVrijeme,
            this.Korisnik});
            this.dgvIzvodjenja.Location = new System.Drawing.Point(41, 102);
            this.dgvIzvodjenja.Name = "dgvIzvodjenja";
            this.dgvIzvodjenja.ReadOnly = true;
            this.dgvIzvodjenja.RowHeadersWidth = 51;
            this.dgvIzvodjenja.RowTemplate.Height = 24;
            this.dgvIzvodjenja.Size = new System.Drawing.Size(688, 284);
            this.dgvIzvodjenja.TabIndex = 0;
            this.dgvIzvodjenja.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvIzvodjenja_MouseDoubleClick);
            // 
            // dtpDatumOD
            // 
            this.dtpDatumOD.Location = new System.Drawing.Point(75, 45);
            this.dtpDatumOD.Name = "dtpDatumOD";
            this.dtpDatumOD.Size = new System.Drawing.Size(200, 22);
            this.dtpDatumOD.TabIndex = 1;
            // 
            // dtpDatumDO
            // 
            this.dtpDatumDO.Location = new System.Drawing.Point(352, 45);
            this.dtpDatumDO.Name = "dtpDatumDO";
            this.dtpDatumDO.Size = new System.Drawing.Size(200, 22);
            this.dtpDatumDO.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Do:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Od:";
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(604, 45);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(75, 23);
            this.btnPretrazi.TabIndex = 5;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // Predstava
            // 
            this.Predstava.DataPropertyName = "PredstavaNaziv";
            this.Predstava.HeaderText = "Predstava";
            this.Predstava.MinimumWidth = 6;
            this.Predstava.Name = "Predstava";
            this.Predstava.ReadOnly = true;
            this.Predstava.Width = 125;
            // 
            // Pozoriste
            // 
            this.Pozoriste.DataPropertyName = "PozoristeNaziv";
            this.Pozoriste.HeaderText = "Pozoriste";
            this.Pozoriste.MinimumWidth = 6;
            this.Pozoriste.Name = "Pozoriste";
            this.Pozoriste.ReadOnly = true;
            this.Pozoriste.Width = 125;
            // 
            // DatumVrijeme
            // 
            this.DatumVrijeme.DataPropertyName = "DatumVrijeme";
            this.DatumVrijeme.HeaderText = "Datum i vrijeme";
            this.DatumVrijeme.MinimumWidth = 6;
            this.DatumVrijeme.Name = "DatumVrijeme";
            this.DatumVrijeme.ReadOnly = true;
            this.DatumVrijeme.Width = 150;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "KorisnikKorisnickoIme";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.MinimumWidth = 6;
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            this.Korisnik.Width = 125;
            // 
            // frmIzvodjenja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDatumDO);
            this.Controls.Add(this.dtpDatumOD);
            this.Controls.Add(this.dgvIzvodjenja);
            this.Name = "frmIzvodjenja";
            this.Text = "Izvodjenja";
            this.Load += new System.EventHandler(this.frmIzvodjenja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvodjenja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIzvodjenja;
        private System.Windows.Forms.DateTimePicker dtpDatumOD;
        private System.Windows.Forms.DateTimePicker dtpDatumDO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Predstava;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pozoriste;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
    }
}