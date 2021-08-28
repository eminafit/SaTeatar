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

namespace SaTeatar.WinUI.Izvjestaji
{
    public partial class frmPostavkaIzvjestajaTopNarudzbe : Form
    {
        private readonly APIService _pozoristeService = new APIService("pozorista");
        private readonly APIService _narudzbaService = new APIService("narudzba");
        private readonly APIService _kupciService = new APIService("kupci");

        public frmPostavkaIzvjestajaTopNarudzbe()
        {
            InitializeComponent();
        }

        public class dtoTopNarudzbe
        {
            public string PozoristeNaziv { get; set; }
            public DateTime DatumOd { get; set; }
            public DateTime DatumDo { get; set; }
            public List<dtoNarudzba> Narudzbe { get; set; }

            public class dtoNarudzba
            {
                public int RedBr { get; set; }
                public string BrNarudzbe { get; set; }
                public string Kupac { get; set; }
                public decimal Iznos { get; set; }
            }

        }


        private async void frmPostavkaIzvjestajaTopNarudzbe_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
        }

        private async Task LoadPozorista()
        {
            var pozorista = await  _pozoristeService.Get<List<mPozorista>>(null);
            pozorista.Insert(0, new mPozorista());
            cmbPozoriste.DisplayMember = "Naziv";
            cmbPozoriste.ValueMember = "PozoristeId";
            cmbPozoriste.DataSource = pozorista;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                var dtobj = new dtoTopNarudzbe();
                dtobj.Narudzbe = new List<dtoTopNarudzbe.dtoNarudzba>();

                var DatumOd = dtpDatumOd.Value.Date;
                var DatumDo = dtpDatumDo.Value.Date;

                dtobj.DatumOd = DatumOd;
                dtobj.DatumDo = DatumDo;


                var id = cmbPozoriste.SelectedValue.ToString();

                if (int.TryParse(id, out int idPozorista))
                {
                    var pozoriste = await _pozoristeService.GetById<mPozorista>(idPozorista);
                    dtobj.PozoristeNaziv = pozoriste.Naziv;

                    var search = new rNarudzbaSearch { PozoristeId = idPozorista, DatumOD = DatumOd, DatumDO = DatumDo };
                    var narudzbe = await _narudzbaService.Get<List<mNarudzba>>(search);
                    narudzbe.Sort((y, x) => x.Iznos.CompareTo(y.Iznos));
                    if (narudzbe.Count>5)
                    {
                        narudzbe = narudzbe.GetRange(0, 5);
                    }

                    int redbr = 1;
                    foreach (var item in narudzbe)
                    {
                        var kupac = await _kupciService.GetById<mKupci>(item.KupacId);

                        dtobj.Narudzbe.Add(new dtoTopNarudzbe.dtoNarudzba()
                        {
                            Kupac = kupac.Ime + " " + kupac.Prezime,
                            BrNarudzbe = item.BrNarudzbe.ToString(),
                            RedBr = redbr,
                            Iznos = item.Iznos
                        });
                        redbr++;
                    }

                    frmTopNarudzbe frm = new frmTopNarudzbe(dtobj);
                    frm.Show();

                }
            }
        }

        private void cmbPozoriste_Validating(object sender, CancelEventArgs e)
        {
            if (cmbPozoriste.SelectedValue == null || int.Parse(cmbPozoriste.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(cmbPozoriste, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbPozoriste, null);
            }
        }

        private void dtpDatumDo_Validating(object sender, CancelEventArgs e)
        {
            //da nije isti kao datumOD ili manji od njega
            if (dtpDatumDo.Value.Date.CompareTo(dtpDatumOd.Value.Date) <= 0)
            {
                errorProvider.SetError(dtpDatumDo, "Pogresan datum, mora biti veci od prije odabranog datuma!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpDatumDo, null);
            }
        }
    }
}
