
namespace SaTeatar.WinUI.Djelatnici
{
    partial class frmDjelatniciDetalji
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBiografija = new System.Windows.Forms.RichTextBox();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.txtSlikaInput = new System.Windows.Forms.TextBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbVrsteDjelatnika = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chStatus = new System.Windows.Forms.CheckBox();
            this.txtSacuvaj = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(163, 45);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(197, 22);
            this.txtIme.TabIndex = 1;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(163, 83);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(197, 22);
            this.txtPrezime.TabIndex = 3;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prezime:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Biografija:";
            // 
            // txtBiografija
            // 
            this.txtBiografija.Location = new System.Drawing.Point(163, 164);
            this.txtBiografija.Name = "txtBiografija";
            this.txtBiografija.Size = new System.Drawing.Size(197, 147);
            this.txtBiografija.TabIndex = 5;
            this.txtBiografija.Text = "";
            // 
            // pbSlika
            // 
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Location = new System.Drawing.Point(417, 45);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(166, 191);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 6;
            this.pbSlika.TabStop = false;
            // 
            // txtSlikaInput
            // 
            this.txtSlikaInput.Location = new System.Drawing.Point(417, 257);
            this.txtSlikaInput.Name = "txtSlikaInput";
            this.txtSlikaInput.Size = new System.Drawing.Size(166, 22);
            this.txtSlikaInput.TabIndex = 7;
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(494, 288);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(89, 23);
            this.btnDodajSliku.TabIndex = 8;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbVrsteDjelatnika
            // 
            this.cmbVrsteDjelatnika.FormattingEnabled = true;
            this.cmbVrsteDjelatnika.Location = new System.Drawing.Point(163, 121);
            this.cmbVrsteDjelatnika.Name = "cmbVrsteDjelatnika";
            this.cmbVrsteDjelatnika.Size = new System.Drawing.Size(197, 24);
            this.cmbVrsteDjelatnika.TabIndex = 9;
            this.cmbVrsteDjelatnika.SelectedIndexChanged += new System.EventHandler(this.cmbVrsteDjelatnika_SelectedIndexChanged);
            this.cmbVrsteDjelatnika.Validating += new System.ComponentModel.CancelEventHandler(this.cmbVrsteDjelatnika_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vrsta djelatnika:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status:";
            this.label5.UseWaitCursor = true;
            // 
            // chStatus
            // 
            this.chStatus.AutoSize = true;
            this.chStatus.Location = new System.Drawing.Point(163, 339);
            this.chStatus.Name = "chStatus";
            this.chStatus.Size = new System.Drawing.Size(18, 17);
            this.chStatus.TabIndex = 12;
            this.chStatus.UseVisualStyleBackColor = true;
            // 
            // txtSacuvaj
            // 
            this.txtSacuvaj.Location = new System.Drawing.Point(327, 353);
            this.txtSacuvaj.Name = "txtSacuvaj";
            this.txtSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.txtSacuvaj.TabIndex = 13;
            this.txtSacuvaj.Text = "Sacuvaj";
            this.txtSacuvaj.UseVisualStyleBackColor = true;
            this.txtSacuvaj.Click += new System.EventHandler(this.txtSacuvaj_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmDjelatniciDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 405);
            this.Controls.Add(this.txtSacuvaj);
            this.Controls.Add(this.chStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbVrsteDjelatnika);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.txtSlikaInput);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.txtBiografija);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label1);
            this.Name = "frmDjelatniciDetalji";
            this.Text = "Djelatnik";
            this.Load += new System.EventHandler(this.frmDjelatniciDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtBiografija;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.TextBox txtSlikaInput;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbVrsteDjelatnika;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chStatus;
        private System.Windows.Forms.Button txtSacuvaj;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}