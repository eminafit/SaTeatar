using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;

namespace SaTeatar.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _korisniciService = new APIService("korisnici");
        private readonly APIService _korisniciUlogeService = new APIService("korisniciuloge");

        public frmKorisnici()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {

            var search = new rKorisniciSearch {KorisnickoIme = txtPretraga.Text};

            var result = await _korisniciService.Get<List<mKorisnici>>(search);
            result.Sort((x, y) => x.Ime.CompareTo(y.Ime));
            
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
            if (result.Count == 0)
            {
                MessageBox.Show("Nema rezultata za zadanu pretragu", "OK");
            }
        }


        private void dgvKorisnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;

            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(id.ToString()));
            frm.Show();
                    
           
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
