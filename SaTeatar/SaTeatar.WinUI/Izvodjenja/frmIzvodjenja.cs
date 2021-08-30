using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;

namespace SaTeatar.WinUI.Izvodjenja
{
    public partial class frmIzvodjenja : Form
    {
        APIService _izvodjenjaService = new APIService("izvodjenja");
        APIService _predstaveService = new APIService("predstava");
        APIService _pozoristaService = new APIService("pozorista");
        APIService _korisniciService = new APIService("korisnici");

        public frmIzvodjenja()
        {
            InitializeComponent();
        }

        private void frmIzvodjenja_Load(object sender, EventArgs e)
        {
            dtpDatumOD.Value = new DateTime(2021, 10, 1);
            dtpDatumDO.Value = new DateTime(2021, 11, 6);
           // await LoadIzvodjenja();
        }

        private async Task LoadIzvodjenja()
        {
            var izvodjenja = await _izvodjenjaService.Get<List<mIzvodjenja>>(null);

            for (int i = 0; i < izvodjenja.Count(); i++)
            {
                mPredstave p = await _predstaveService.GetById<mPredstave>(izvodjenja[i].PredstavaId);
                izvodjenja[i].PredstavaNaziv = p.Naziv;
                mPozorista t = await _pozoristaService.GetById<mPozorista>(izvodjenja[i].PozoristeId);
                izvodjenja[i].PozoristeNaziv = t.Naziv;
                mKorisnici k = await _korisniciService.GetById<mKorisnici>(izvodjenja[i].KorisnikId);
                izvodjenja[i].KorisnikKorisnickoIme = k.KorisnickoIme;
            }
            dgvIzvodjenja.AutoGenerateColumns = false;
            dgvIzvodjenja.DataSource = izvodjenja;

        }

        private void dgvIzvodjenja_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var redIndex = dgvIzvodjenja.CurrentCell.RowIndex;
            var idIzvodjenja = dgvIzvodjenja.Rows[redIndex].Cells["IzvodjenjeId"].Value;
            frmIzvodjenjeDetalji frm = new frmIzvodjenjeDetalji(int.Parse(idIzvodjenja.ToString()));
            frm.Show();
        }

        private async void btnPretrazi_Click(object sender, EventArgs e)
        {
            var DatumOd = dtpDatumOD.Value.Date;
            var DatumDo = dtpDatumDO.Value.Date;

            var search = new rIzvodjenjaSearch { DatumOD = DatumOd, DatumDO = DatumDo };
            var result = await _izvodjenjaService.Get<List<mIzvodjenja>>(search);
            result.Sort((x, y) => x.DatumVrijeme.CompareTo(y.DatumVrijeme));

            dgvIzvodjenja.AutoGenerateColumns = false;
            dgvIzvodjenja.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Nema rezultata za zadanu pretragu", "OK");
            }

        }


    }
}
