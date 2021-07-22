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

        private async void frmIzvodjenja_Load(object sender, EventArgs e)
        {
            //var izvodjenja = await _izvodjenjaService.Get<List<mIzvodjenja>>(null);
            //for (int i = 0; i < izvodjenja.Count(); i++)
            //{
            //    mPredstave p= await _predstaveService.GetById<mPredstave>(izvodjenja[i].PredstavaId);
            //    izvodjenja[i].Predstava = p.Naziv;
            //    mPredstave t = await _pozoristaService.GetById<mPredstave>(izvodjenja[i].PozoristeId);
            //    izvodjenja[i].Pozoriste = t.Naziv;
            //}
            //dgvIzvodjenja.DataSource = izvodjenja;
            await LoadIzvodjenja();
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
    }
}
