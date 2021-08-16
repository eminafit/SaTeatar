
namespace SaTeatar.WinUI.Izvodjenja
{
    partial class frmIzvodjenjeDetalji
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPredstave = new System.Windows.Forms.ComboBox();
            this.cmbPozoriste = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Korisnik = new System.Windows.Forms.Label();
            this.txtKorisnik = new System.Windows.Forms.TextBox();
            this.dtpDatumVrijeme = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.RichTextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvZone = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSacuvajCijeneZona = new System.Windows.Forms.Button();
            this.ZonaNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IzvodjenjeZonaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZone)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Predstava: ";
            // 
            // cmbPredstave
            // 
            this.cmbPredstave.FormattingEnabled = true;
            this.cmbPredstave.Location = new System.Drawing.Point(136, 42);
            this.cmbPredstave.Name = "cmbPredstave";
            this.cmbPredstave.Size = new System.Drawing.Size(258, 24);
            this.cmbPredstave.TabIndex = 1;
            this.cmbPredstave.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPredstave_Validating);
            // 
            // cmbPozoriste
            // 
            this.cmbPozoriste.FormattingEnabled = true;
            this.cmbPozoriste.Location = new System.Drawing.Point(136, 86);
            this.cmbPozoriste.Name = "cmbPozoriste";
            this.cmbPozoriste.Size = new System.Drawing.Size(258, 24);
            this.cmbPozoriste.TabIndex = 3;
            this.cmbPozoriste.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPozoriste_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pozoriste:";
            // 
            // Korisnik
            // 
            this.Korisnik.AutoSize = true;
            this.Korisnik.Location = new System.Drawing.Point(59, 297);
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.Size = new System.Drawing.Size(62, 17);
            this.Korisnik.TabIndex = 4;
            this.Korisnik.Text = "Korisnik:";
            // 
            // txtKorisnik
            // 
            this.txtKorisnik.Location = new System.Drawing.Point(136, 297);
            this.txtKorisnik.Name = "txtKorisnik";
            this.txtKorisnik.Size = new System.Drawing.Size(258, 22);
            this.txtKorisnik.TabIndex = 5;
            // 
            // dtpDatumVrijeme
            // 
            this.dtpDatumVrijeme.Location = new System.Drawing.Point(136, 131);
            this.dtpDatumVrijeme.Name = "dtpDatumVrijeme";
            this.dtpDatumVrijeme.Size = new System.Drawing.Size(200, 22);
            this.dtpDatumVrijeme.TabIndex = 7;
            this.dtpDatumVrijeme.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatumVrijeme_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Datum i vrijeme:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Napomena:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(136, 185);
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(258, 94);
            this.txtNapomena.TabIndex = 10;
            this.txtNapomena.Text = "";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(306, 362);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 11;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dgvZone
            // 
            this.dgvZone.AllowUserToAddRows = false;
            this.dgvZone.AllowUserToDeleteRows = false;
            this.dgvZone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZonaNaziv,
            this.IzvodjenjeZonaId,
            this.Cijena});
            this.dgvZone.Location = new System.Drawing.Point(453, 86);
            this.dgvZone.Name = "dgvZone";
            this.dgvZone.RowHeadersWidth = 51;
            this.dgvZone.RowTemplate.Height = 24;
            this.dgvZone.Size = new System.Drawing.Size(303, 150);
            this.dgvZone.TabIndex = 16;
            this.dgvZone.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvZone_DataError);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dodajte cijene za svaku zonu:";
            // 
            // btnSacuvajCijeneZona
            // 
            this.btnSacuvajCijeneZona.Location = new System.Drawing.Point(605, 256);
            this.btnSacuvajCijeneZona.Name = "btnSacuvajCijeneZona";
            this.btnSacuvajCijeneZona.Size = new System.Drawing.Size(151, 23);
            this.btnSacuvajCijeneZona.TabIndex = 17;
            this.btnSacuvajCijeneZona.Text = "Sacuvaj cijene zona";
            this.btnSacuvajCijeneZona.UseVisualStyleBackColor = true;
            this.btnSacuvajCijeneZona.Click += new System.EventHandler(this.btnSacuvajCijeneZona_Click);
            // 
            // ZonaNaziv
            // 
            this.ZonaNaziv.DataPropertyName = "ZonaNaziv";
            this.ZonaNaziv.HeaderText = "Zona";
            this.ZonaNaziv.MinimumWidth = 6;
            this.ZonaNaziv.Name = "ZonaNaziv";
            this.ZonaNaziv.Width = 125;
            // 
            // IzvodjenjeZonaId
            // 
            this.IzvodjenjeZonaId.DataPropertyName = "IzvodjenjeZonaId";
            this.IzvodjenjeZonaId.HeaderText = "IzvodjenjeZonaId";
            this.IzvodjenjeZonaId.MinimumWidth = 6;
            this.IzvodjenjeZonaId.Name = "IzvodjenjeZonaId";
            this.IzvodjenjeZonaId.ReadOnly = true;
            this.IzvodjenjeZonaId.Visible = false;
            this.IzvodjenjeZonaId.Width = 125;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.Width = 125;
            // 
            // frmIzvodjenjeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.btnSacuvajCijeneZona);
            this.Controls.Add(this.dgvZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDatumVrijeme);
            this.Controls.Add(this.txtKorisnik);
            this.Controls.Add(this.Korisnik);
            this.Controls.Add(this.cmbPozoriste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPredstave);
            this.Controls.Add(this.label1);
            this.Name = "frmIzvodjenjeDetalji";
            this.Text = "Izvodjenje";
            this.Load += new System.EventHandler(this.frmIzvodjenjeDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPredstave;
        private System.Windows.Forms.ComboBox cmbPozoriste;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Korisnik;
        private System.Windows.Forms.TextBox txtKorisnik;
        private System.Windows.Forms.DateTimePicker dtpDatumVrijeme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtNapomena;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgvZone;
        private System.Windows.Forms.Button btnSacuvajCijeneZona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZonaNaziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn IzvodjenjeZonaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
    }
}