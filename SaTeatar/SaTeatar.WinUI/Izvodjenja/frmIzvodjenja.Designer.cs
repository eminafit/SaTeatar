
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
            this.Predstava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pozoriste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Napomena = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Napomena,
            this.Korisnik});
            this.dgvIzvodjenja.Location = new System.Drawing.Point(25, 101);
            this.dgvIzvodjenja.Name = "dgvIzvodjenja";
            this.dgvIzvodjenja.ReadOnly = true;
            this.dgvIzvodjenja.RowHeadersWidth = 51;
            this.dgvIzvodjenja.RowTemplate.Height = 24;
            this.dgvIzvodjenja.Size = new System.Drawing.Size(688, 284);
            this.dgvIzvodjenja.TabIndex = 0;
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
            // Napomena
            // 
            this.Napomena.DataPropertyName = "Napomena";
            this.Napomena.HeaderText = "Napomena";
            this.Napomena.MinimumWidth = 6;
            this.Napomena.Name = "Napomena";
            this.Napomena.ReadOnly = true;
            this.Napomena.Width = 125;
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
            this.Controls.Add(this.dgvIzvodjenja);
            this.Name = "frmIzvodjenja";
            this.Text = "a";
            this.Load += new System.EventHandler(this.frmIzvodjenja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvodjenja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIzvodjenja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Predstava;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pozoriste;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVrijeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Napomena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
    }
}