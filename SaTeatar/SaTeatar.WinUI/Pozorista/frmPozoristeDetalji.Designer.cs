
namespace SaTeatar.WinUI.Pozorista
{
    partial class frmPozoristeDetalji
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.txtAdresa = new System.Windows.Forms.RichTextBox();
            this.txtSlikaInput = new System.Windows.Forms.TextBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnDodajZone = new System.Windows.Forms.Button();
            this.lbZone = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrikaziZone = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(99, 52);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(231, 22);
            this.txtNaziv.TabIndex = 1;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adresa:";
            // 
            // pbSlika
            // 
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Location = new System.Drawing.Point(363, 52);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(197, 184);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 4;
            this.pbSlika.TabStop = false;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(99, 96);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(231, 88);
            this.txtAdresa.TabIndex = 5;
            this.txtAdresa.Text = "";
            this.txtAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdresa_Validating);
            // 
            // txtSlikaInput
            // 
            this.txtSlikaInput.Location = new System.Drawing.Point(363, 254);
            this.txtSlikaInput.Name = "txtSlikaInput";
            this.txtSlikaInput.Size = new System.Drawing.Size(197, 22);
            this.txtSlikaInput.TabIndex = 6;
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(473, 282);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(87, 23);
            this.btnDodajSliku.TabIndex = 7;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(662, 327);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnDodajZone
            // 
            this.btnDodajZone.Location = new System.Drawing.Point(685, 254);
            this.btnDodajZone.Name = "btnDodajZone";
            this.btnDodajZone.Size = new System.Drawing.Size(95, 28);
            this.btnDodajZone.TabIndex = 9;
            this.btnDodajZone.Text = "Dodaj zone";
            this.btnDodajZone.UseVisualStyleBackColor = true;
            this.btnDodajZone.Click += new System.EventHandler(this.btnDodajZone_Click);
            // 
            // lbZone
            // 
            this.lbZone.FormattingEnabled = true;
            this.lbZone.ItemHeight = 16;
            this.lbZone.Location = new System.Drawing.Point(609, 84);
            this.lbZone.Name = "lbZone";
            this.lbZone.Size = new System.Drawing.Size(171, 148);
            this.lbZone.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Zone:";
            // 
            // txtPrikaziZone
            // 
            this.txtPrikaziZone.Location = new System.Drawing.Point(704, 46);
            this.txtPrikaziZone.Name = "txtPrikaziZone";
            this.txtPrikaziZone.Size = new System.Drawing.Size(67, 23);
            this.txtPrikaziZone.TabIndex = 12;
            this.txtPrikaziZone.Text = "Prikazi";
            this.txtPrikaziZone.UseVisualStyleBackColor = true;
            this.txtPrikaziZone.Click += new System.EventHandler(this.txtPrikaziZone_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmPozoristeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 378);
            this.Controls.Add(this.txtPrikaziZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbZone);
            this.Controls.Add(this.btnDodajZone);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.txtSlikaInput);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label1);
            this.Name = "frmPozoristeDetalji";
            this.Text = "Pozoriste";
            this.Load += new System.EventHandler(this.frmPozoristeDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.RichTextBox txtAdresa;
        private System.Windows.Forms.TextBox txtSlikaInput;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnDodajZone;
        private System.Windows.Forms.ListBox lbZone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button txtPrikaziZone;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}