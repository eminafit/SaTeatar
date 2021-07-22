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

namespace SaTeatar.WinUI.Djelatnici
{
    public partial class frmDjelatnici : Form
    {
        private APIService _djelatniciService = new APIService("djelatnici");
        private APIService _vrsteDjelatnikaService = new APIService("vrstedjelatnika");

        public frmDjelatnici()
        {
            InitializeComponent();
        }

        private async void frmDjelatnici_Load(object sender, EventArgs e)
        {
            await LoadVrsteDjelatnika();
        }


        private async Task LoadVrsteDjelatnika()
        {
            var result = await _vrsteDjelatnikaService.Get<List<mVrsteDjelatnika>>(null);
            result.Insert(0, new mVrsteDjelatnika());           
            cmbDjelatnici.DisplayMember = "Naziv";
            cmbDjelatnici.ValueMember = "VrstaDjelatnikaId";
            cmbDjelatnici.DataSource = result;
        }

        private async void cmbDjelatnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idVDobj = cmbDjelatnici.SelectedValue;
            if (int.TryParse(idVDobj.ToString(),out int idvd))
            {
                if (idvd!=0)
                {
                    await LoadDjelatnike(idvd);
                }
            }
        }

        private async Task LoadDjelatnike(int vdid)
        {
            var result = await _djelatniciService.Get<List<mDjelatnici>>
                (new rDjelatniciSearch ()
                    { 
                        VrstaDjelatnikaId = vdid 
                    }
                );
            dgvDjelatnici.AutoGenerateColumns = false;
            dgvDjelatnici.DataSource = result;
        }


        private async void btnPretrazi_Click(object sender, EventArgs e)
        {
            var result = await _djelatniciService.Get<List<mDjelatnici>>
                (new rDjelatniciSearch()
                    {
                        Ime = txtIme.Text,
                        Prezime=txtPrezime.Text
                    }
                );
            dgvDjelatnici.AutoGenerateColumns = false;
            dgvDjelatnici.DataSource = result;
        }

        private void dgvDjelatnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int redIndex = dgvDjelatnici.CurrentCell.RowIndex;
            var did = dgvDjelatnici.Rows[redIndex].Cells["DjelatnikId"].Value;
            frmDjelatniciDetalji frm = new frmDjelatniciDetalji(int.Parse(did.ToString()));
            frm.Show();

        }
    }
}
