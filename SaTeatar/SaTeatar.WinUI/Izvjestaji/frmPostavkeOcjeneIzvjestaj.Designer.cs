
namespace SaTeatar.WinUI.Izvjestaji
{
    partial class frmPostavkeOcjeneIzvjestaj
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
            this.cmbPozorista = new System.Windows.Forms.ComboBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pozoriste:";
            // 
            // cmbPozorista
            // 
            this.cmbPozorista.FormattingEnabled = true;
            this.cmbPozorista.Location = new System.Drawing.Point(125, 47);
            this.cmbPozorista.Name = "cmbPozorista";
            this.cmbPozorista.Size = new System.Drawing.Size(248, 24);
            this.cmbPozorista.TabIndex = 1;
            this.cmbPozorista.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPozorista_Validating);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(198, 101);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(132, 23);
            this.btnPrikazi.TabIndex = 2;
            this.btnPrikazi.Text = "Prikazi izvjestaj";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmPostavkeOcjeneIzvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 166);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.cmbPozorista);
            this.Controls.Add(this.label1);
            this.Name = "frmPostavkeOcjeneIzvjestaj";
            this.Text = "Najbolje ocijenjene predstave";
            this.Load += new System.EventHandler(this.frmPostavkeOcjeneIzvjestaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPozorista;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}