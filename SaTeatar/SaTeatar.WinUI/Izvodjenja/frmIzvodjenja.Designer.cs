
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvodjenja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIzvodjenja
            // 
            this.dgvIzvodjenja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvodjenja.Location = new System.Drawing.Point(28, 125);
            this.dgvIzvodjenja.Name = "dgvIzvodjenja";
            this.dgvIzvodjenja.RowHeadersWidth = 51;
            this.dgvIzvodjenja.RowTemplate.Height = 24;
            this.dgvIzvodjenja.Size = new System.Drawing.Size(711, 284);
            this.dgvIzvodjenja.TabIndex = 0;
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
    }
}