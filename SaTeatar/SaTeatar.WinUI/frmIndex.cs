using SaTeatar.WinUI.Djelatnici;
using SaTeatar.WinUI.Izvjestaji;
using SaTeatar.WinUI.Izvodjenja;
using SaTeatar.WinUI.Korisnici;
using SaTeatar.WinUI.Pozorista;
using SaTeatar.WinUI.Predstave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaTeatar.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
        //        if (f.Name != "Menu")
                    f.Close();
            }

            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPredstave frm = new frmPredstave();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novaPredstavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPredstaveDetalji frm = new frmPredstaveDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDjelatnici frm = new frmDjelatnici();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviDjelatnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDjelatniciDetalji frm = new frmDjelatniciDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmPozorista frm = new frmPozorista();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void novoPozoristeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPozoristeDetalji frm = new frmPozoristeDetalji();
            frm.Show();
        }

        private void novoIzvodjenjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzvodjenjeDetalji frm = new frmIzvodjenjeDetalji();
            frm.Show();
        }

        private void pretragaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmIzvodjenja frm = new frmIzvodjenja();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private bool bClosing;

        private void frmIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bClosing)
            {
                bClosing = true;

                if (MessageBox.Show("Da li ste sigurni da zelite zatvoriti aplikaciju?", "Izlaz", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    bClosing=false;
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                bClosing = false;
            }
        }

        private void topPosjetiteljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPostavkeZaIzvjestaje frm = new frmPostavkeZaIzvjestaje();
            frm.MdiParent = this;
            frm.Show();
        }

        private void top5NarudzbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPostavkaIzvjestajaTopNarudzbe frm = new frmPostavkaIzvjestajaTopNarudzbe();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
