using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;


namespace SaTeatar.WinUI.Pozorista
{
    public partial class frmPozoristeDetalji : Form
    {
        APIService _pozoristaService = new APIService("pozorista");
        APIService _zoneService = new APIService("zone");
        private int? _id = null;

        public frmPozoristeDetalji(int? pozoristeId=null)
        {
            InitializeComponent();
            _id = pozoristeId;
        }

        rPozoristaInsert inrequest = new rPozoristaInsert();
        rPozoristaUpdate uprequest = new rPozoristaUpdate();
        mPozorista pozoriste = new mPozorista();
        private bool dodanaSlika = false;
            

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result==DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                if (_id.HasValue)
                {
                    uprequest.Logo = file;
                }
                else
                {
                    inrequest.Logo = file;
                }
                txtSlikaInput.Text = filename;
                Image slika = Image.FromFile(filename);
                pbSlika.Image = slika;

            }

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                uprequest.Naziv = txtNaziv.Text;
                uprequest.Adresa = txtAdresa.Text;
                if (!dodanaSlika)
                {
                    uprequest.Logo = pozoriste.Logo;
                }
                await _pozoristaService.Update<mPozorista>(_id, uprequest);
                MessageBox.Show("Pozoriste uspjesno izmijenjeno!");

            }
            else
            {
                inrequest.Naziv = txtNaziv.Text;
                inrequest.Adresa = txtAdresa.Text;

                pozoriste = await _pozoristaService.Insert<mPozorista>(inrequest);
                MessageBox.Show("Pozoriste uspjesno dodato!");
            }

        }

        private void btnDodajZone_Click(object sender, EventArgs e)
        {
            if (pozoriste.PozoristeId==0)
            {
                MessageBox.Show("Pozoriste se treba najprije dodati! Kliknuti na dugme 'Sacuvaj'");

               // btnSacuvaj_Click(null, null);
            }
            else
            {
                frmZonaDetalji frm = new frmZonaDetalji(pozoriste.PozoristeId, pozoriste.Naziv);
                //frm.MdiParent = this;
               // frm.Parent = this;
                frm.Show();
            }
        }

        private async void frmPozoristeDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                pozoriste = await _pozoristaService.GetById<mPozorista>(_id);

                txtNaziv.Text = pozoriste.Naziv;
                txtAdresa.Text = pozoriste.Adresa;
                if (pozoriste.Logo?.Length>0)
                {
                    using(MemoryStream ms = new MemoryStream(pozoriste.Logo))
                    {
                        pbSlika.Image = Image.FromStream(ms);
                    }
                }

                var zone = await _zoneService.Get<List<mZone>>(new rZoneSearch() { PozoristeId=(int)_id});
                lbZone.DataSource = zone;
                lbZone.DisplayMember = "NazivSjedista";
            }
        }

        private async void txtPrikaziZone_Click(object sender, EventArgs e)
        {
            if (pozoriste.PozoristeId != 0)
            {
                rZoneSearch zahtjev = new rZoneSearch() { PozoristeId = pozoriste.PozoristeId };
                var zone = await _zoneService.Get<List<mZone>>(zahtjev);
                lbZone.DisplayMember = "NazivSjedista";
                lbZone.DataSource = zone;
            }
            else
            {
                MessageBox.Show("Zone nisu dodate!");
            }
        }
    }
}
