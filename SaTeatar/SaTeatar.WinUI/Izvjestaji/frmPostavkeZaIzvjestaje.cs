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

namespace SaTeatar.WinUI
{
    public partial class frmPostavkeZaIzvjestaje : Form
    {
        private readonly APIService _pozoristaService = new APIService("pozorista");
        private readonly APIService _karteService = new APIService("karte");
        private readonly APIService _kupciService = new APIService("kupci");
        public frmPostavkeZaIzvjestaje()
        {
            InitializeComponent();
        }

        public class dtoTopPosjetioci
        {
            public string PozoristeNaziv { get; set; }
            public DateTime DatumOd { get; set; }
            public DateTime DatumDo { get; set; }
            public List<dtoKupac> Kupci { get; set; }
            public int BrojKupaca { get; set; }

            public class dtoKupac
            {
                public int RedBr { get; set; }
                public int KupacId { get; set; }
                public string KupacImePrezime { get; set; }
                public int BrKarti { get; set; }
            }

        }

        private async void frmPostavkeZaIzvjestaje_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
            dtpDatumOd.Value = new DateTime(2021, 8, 1);
            dtpDatumDo.Value = new DateTime(2021, 8, 21);
        }

        private async Task LoadPozorista()
        {
            var pozorista = await _pozoristaService.Get<List<mPozorista>>(null);
            pozorista.Insert(0, new mPozorista());
            cmbPozorista.DisplayMember = "Naziv";
            cmbPozorista.ValueMember = "PozoristeId";
            cmbPozorista.DataSource = pozorista;

        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {


                var obj = new dtoTopPosjetioci();
                obj.Kupci = new List<dtoTopPosjetioci.dtoKupac>();
                var pid = cmbPozorista.SelectedValue.ToString();
                if (int.TryParse(pid, out int pozoristeId))
                {
                    var pozoriste = await _pozoristaService.GetById<mPozorista>(pozoristeId);
                    obj.PozoristeNaziv = pozoriste.Naziv;
                    obj.DatumOd = dtpDatumOd.Value;
                    obj.DatumDo = dtpDatumDo.Value;
                    obj.BrojKupaca = 3;

                    var search = new rKartaSearch() { PozoristeId = pozoristeId, Placeno = true, DatumDo = obj.DatumDo, DatumOd = obj.DatumOd };
                    var karte = await _karteService.Get<List<mKarta>>(search);

                    var kupci_ids = karte.Select(x => x.KupacId).Distinct();

                    foreach (var id in kupci_ids)
                    {
                        obj.Kupci.Add(new dtoTopPosjetioci.dtoKupac()
                        {
                            RedBr = 0,
                            KupacId = id,
                            KupacImePrezime = "...",
                            BrKarti = 0
                        });
                    }

                    for (int i = 0; i < karte.Count; i++)
                    {
                        for (int j = 0; j < obj.Kupci.Count; j++)
                        {
                            if (karte[i].KupacId == obj.Kupci[j].KupacId)
                            {
                                if (obj.Kupci[j].BrKarti == 0)
                                {
                                    obj.Kupci[j].KupacImePrezime = $"{karte[i].KupacIme} {karte[i].KupacPrezime}";
                                    obj.Kupci[j].BrKarti += 1;
                                }
                                else
                                {
                                    obj.Kupci[j].BrKarti += 1;
                                }
                            }
                        }
                    }

                    obj.Kupci.Sort((y, x) => x.BrKarti.CompareTo(y.BrKarti));
                    //public void RemoveRange (int index, int count); //skida i index
                    int range = obj.Kupci.Count - obj.BrojKupaca;
                    if (range > 0)
                    {
                        obj.Kupci.RemoveRange(obj.BrojKupaca, range);
                    }
                    for (int i = 0; i < obj.Kupci.Count; i++)
                    {
                        obj.Kupci[i].RedBr = i + 1;
                    }
                }

                frmTopPosjetiteljiIzvjestaj frm = new frmTopPosjetiteljiIzvjestaj(obj);
                frm.Show();
            }
        }

        private void cmbPozorista_Validating(object sender, CancelEventArgs e)
        {
            if (cmbPozorista.SelectedValue == null || int.Parse(cmbPozorista.SelectedValue.ToString()) == 0)
            {
                errorProvider.SetError(cmbPozorista, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbPozorista, null);
            }
        }

        //private async void txtBrPosjetitelja_Validating(object sender, CancelEventArgs e)
        //{
        //    var kupci = await _kupciService.Get<List<mKupci>>(null);
        //    var brKupaca = kupci.Count;
        //    if (string.IsNullOrWhiteSpace(txtBrPosjetitelja.Text))
        //    {
        //        errorProvider.SetError(txtBrPosjetitelja, "Unesite broj");
        //        e.Cancel = true;
        //    }
        //    else
        //    if (!int.TryParse(txtBrPosjetitelja.Text, out int broj))
        //    {
        //        errorProvider.SetError(txtBrPosjetitelja, "Unesite broj");
        //        e.Cancel = true;
        //    }
        //    else
        //    {
        //        if (broj<0 || broj>brKupaca)
        //        {
        //            errorProvider.SetError(txtBrPosjetitelja, $"Broj moze biti u rasponu od 1 do {brKupaca}!");
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            errorProvider.SetError(txtBrPosjetitelja, null);
        //        }
        //    }          
        //}

        //private void dtpDatumOd_Validating(object sender, CancelEventArgs e)
        //{
        //    //nemam sta
        //}

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
