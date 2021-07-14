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

namespace SaTeatar.WinUI.Pozorista
{
    public partial class frmZonaDetalji : Form
    {
        APIService _zoneService = new APIService("zone");
        private string _nazivPozorista = "";
        private int _pozoristeid = 0;
        public frmZonaDetalji(int? pozoristeid=null, string nazivPozorista=null)
        {
            if (pozoristeid!=null)
            {
                _pozoristeid = int.Parse(pozoristeid.ToString());
            }
            if (nazivPozorista != null)
            {
                _nazivPozorista = nazivPozorista;
            }
            InitializeComponent();
        }

        private void frmZonaDetalji_Load(object sender, EventArgs e)
        {
            txtPozoriste.Text = _nazivPozorista;
            txtPozoriste.Enabled = false;   
           // txtPozoriste.Enabled = false;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            rZoneInsert zahtjev = new rZoneInsert()
            {
                Naziv = txtNaziv.Text,
                PozoristeId = _pozoristeid,
                UkupanBrojSjedista = int.Parse(txtUkupanBrojSjedista.Text)
            };

            await _zoneService.Insert<mZone>(zahtjev);
            MessageBox.Show("Zona uspjesno dodata!");
            this.Close();
            //this.Parent.Refresh();
        }
    }
}
