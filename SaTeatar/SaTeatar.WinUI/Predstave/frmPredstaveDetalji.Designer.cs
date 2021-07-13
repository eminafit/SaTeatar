
namespace SaTeatar.WinUI.Predstave
{
    partial class frmPredstaveDetalji
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.Rezija = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.txtOpis = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipPredstave = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbStatus = new System.Windows.Forms.CheckBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSlikaInput = new System.Windows.Forms.TextBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbGlumci = new System.Windows.Forms.ListBox();
            this.cmbRezija = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(97, 28);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(272, 22);
            this.txtNaziv.TabIndex = 1;
            // 
            // Rezija
            // 
            this.Rezija.AutoSize = true;
            this.Rezija.Location = new System.Drawing.Point(38, 124);
            this.Rezija.Name = "Rezija";
            this.Rezija.Size = new System.Drawing.Size(51, 17);
            this.Rezija.TabIndex = 2;
            this.Rezija.Text = "Rezija:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Glumci:";
            // 
            // pbSlika
            // 
            this.pbSlika.Location = new System.Drawing.Point(418, 28);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(201, 261);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 6;
            this.pbSlika.TabStop = false;
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(97, 167);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(272, 138);
            this.txtOpis.TabIndex = 7;
            this.txtOpis.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Opis:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status: ";
            // 
            // cmbTipPredstave
            // 
            this.cmbTipPredstave.FormattingEnabled = true;
            this.cmbTipPredstave.Location = new System.Drawing.Point(97, 75);
            this.cmbTipPredstave.Name = "cmbTipPredstave";
            this.cmbTipPredstave.Size = new System.Drawing.Size(272, 24);
            this.cmbTipPredstave.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tip:";
            // 
            // chbStatus
            // 
            this.chbStatus.AutoSize = true;
            this.chbStatus.Location = new System.Drawing.Point(97, 326);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(18, 17);
            this.chbStatus.TabIndex = 13;
            this.chbStatus.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(928, 358);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 14;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Slika:";
            // 
            // txtSlikaInput
            // 
            this.txtSlikaInput.Location = new System.Drawing.Point(418, 321);
            this.txtSlikaInput.Name = "txtSlikaInput";
            this.txtSlikaInput.Size = new System.Drawing.Size(201, 22);
            this.txtSlikaInput.TabIndex = 16;
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(531, 358);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(88, 23);
            this.btnDodajSliku.TabIndex = 17;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseCompatibleTextRendering = true;
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbGlumci
            // 
            this.lbGlumci.FormattingEnabled = true;
            this.lbGlumci.ItemHeight = 16;
            this.lbGlumci.Location = new System.Drawing.Point(649, 50);
            this.lbGlumci.Name = "lbGlumci";
            this.lbGlumci.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbGlumci.Size = new System.Drawing.Size(365, 292);
            this.lbGlumci.TabIndex = 18;
            // 
            // cmbRezija
            // 
            this.cmbRezija.FormattingEnabled = true;
            this.cmbRezija.Location = new System.Drawing.Point(97, 124);
            this.cmbRezija.Name = "cmbRezija";
            this.cmbRezija.Size = new System.Drawing.Size(272, 24);
            this.cmbRezija.TabIndex = 19;
            // 
            // frmPredstaveDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 407);
            this.Controls.Add(this.cmbRezija);
            this.Controls.Add(this.lbGlumci);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.txtSlikaInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.chbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipPredstave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Rezija);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label1);
            this.Name = "frmPredstaveDetalji";
            this.Text = "Dodaj predstavu";
            this.Load += new System.EventHandler(this.frmPredstaveDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label Rezija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.RichTextBox txtOpis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipPredstave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbStatus;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSlikaInput;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lbGlumci;
        private System.Windows.Forms.ComboBox cmbRezija;
    }
}