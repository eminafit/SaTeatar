
namespace SaTeatar.WinUI
{
    partial class frmPostavkeZaIzvjestaje
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBrPosjetitelja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPozorista = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrikazi);
            this.groupBox1.Controls.Add(this.dtpDatumDo);
            this.groupBox1.Controls.Add(this.dtpDatumOd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBrPosjetitelja);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPozorista);
            this.groupBox1.Location = new System.Drawing.Point(36, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 320);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top posjetitelji";
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(171, 255);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(125, 23);
            this.btnPrikazi.TabIndex = 8;
            this.btnPrikazi.Text = "Prikazi izvjestaj";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.Location = new System.Drawing.Point(113, 192);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(200, 22);
            this.dtpDatumDo.TabIndex = 7;
            this.dtpDatumDo.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatumDo_Validating);
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.Location = new System.Drawing.Point(113, 147);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(200, 22);
            this.dtpDatumOd.TabIndex = 6;
            this.dtpDatumOd.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatumOd_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Do datuma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Od datuma:";
            // 
            // txtBrPosjetitelja
            // 
            this.txtBrPosjetitelja.Location = new System.Drawing.Point(146, 101);
            this.txtBrPosjetitelja.Name = "txtBrPosjetitelja";
            this.txtBrPosjetitelja.Size = new System.Drawing.Size(167, 22);
            this.txtBrPosjetitelja.TabIndex = 3;
            this.txtBrPosjetitelja.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrPosjetitelja_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Broj posjetitelja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pozoriste:";
            // 
            // cmbPozorista
            // 
            this.cmbPozorista.FormattingEnabled = true;
            this.cmbPozorista.Location = new System.Drawing.Point(96, 50);
            this.cmbPozorista.Name = "cmbPozorista";
            this.cmbPozorista.Size = new System.Drawing.Size(217, 24);
            this.cmbPozorista.TabIndex = 0;
            this.cmbPozorista.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPozorista_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(18, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(388, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Napomena za testiranje - seed podataka ide od 01.06.2021.";
            // 
            // frmPostavkeZaIzvjestaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPostavkeZaIzvjestaje";
            this.Text = "frmPostavkeZaIzvjestaje";
            this.Load += new System.EventHandler(this.frmPostavkeZaIzvjestaje_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.DateTimePicker dtpDatumOd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBrPosjetitelja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPozorista;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label5;
    }
}