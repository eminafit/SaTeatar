using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaTeatar.WinUI.Pozorista
{
    public partial class frmPozorista : Form
    {
        private APIService _pozoristaService = new APIService("pozorista");
        public frmPozorista()
        {
            InitializeComponent();
        }

        private void frmPozorista_Load(object sender, EventArgs e)
        {
        }


        private async void btnPretrazi_Click(object sender, EventArgs e)
        {
            var pretraga = txtPretraga.Text;
            var request = new rPozoristaSearch() { Naziv = pretraga };
            var result = await _pozoristaService.Get<List<mPozorista>>(request);
            result.Sort((x, y) => x.Naziv.CompareTo(y.Naziv));
            dgvPozorista.AutoGenerateColumns = false;
            dgvPozorista.DataSource = result;
            if (result.Count == 0)
            {
                MessageBox.Show("Nema rezultata za zadanu pretragu", "OK");
            }
        }

        private void dgvPozorista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var redIndex = dgvPozorista.CurrentCell.RowIndex;
            var idPozorista = dgvPozorista.Rows[redIndex].Cells["PozoristeId"].Value;
            frmPozoristeDetalji frm = new frmPozoristeDetalji(int.Parse(idPozorista.ToString()));
            frm.Show();
        }
    }
}
