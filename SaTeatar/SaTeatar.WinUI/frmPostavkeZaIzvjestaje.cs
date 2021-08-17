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

            public class dtoKupac
            {
                public int KupacId { get; set; }
                public string KupacImePrezime { get; set; }
                public int BrKarti { get; set; }
            }


        }

        private async void frmPostavkeZaIzvjestaje_Load(object sender, EventArgs e)
        {
            await LoadPozorista();
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
            var obj = new dtoTopPosjetioci();
            obj.Kupci = new List<dtoTopPosjetioci.dtoKupac>();
            var pid = cmbPozorista.SelectedValue.ToString();
            if (int.TryParse(pid, out int pozoristeId))
            {
                var pozoriste = await _pozoristaService.GetById<mPozorista>(pozoristeId);
                obj.PozoristeNaziv = pozoriste.Naziv;
                obj.DatumOd = dtpDatumOd.Value;
                obj.DatumDo = dtpDatumDo.Value;

                var search = new rKartaSearch() { PozoristeId = pozoristeId , Placeno = true };
                var karte = await _karteService.Get<List<mKarta>>(search);

                //foreach (var item in karte)
                //{
                //    item.Placeno = true;
                //    await _karteService.Update<mKarta>(item.KartaId, item);
                //}

                  var kupci_ids = karte.Select(x => x.KupacId).Distinct();

                foreach (var id in kupci_ids)
                {                   
                    obj.Kupci.Add(new dtoTopPosjetioci.dtoKupac()
                    {
                        KupacId = id,
                        KupacImePrezime="...",
                        BrKarti = 0
                    }) ;
                }

                for (int i = 0; i < karte.Count; i++)
                {
                    for (int j = 0; j < obj.Kupci.Count; j++)
                    {
                        if (karte[i].KupacId==obj.Kupci[j].KupacId)
                        {
                            if (obj.Kupci[j].BrKarti==0)
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

                // obj.Kupci.OrderBy(x => x.BrKarti);
                obj.Kupci.Sort((y, x) => x.BrKarti.CompareTo(y.BrKarti));
            }

            frmTopPosjetiteljiIzvjestaj frm = new frmTopPosjetiteljiIzvjestaj(obj);
            frm.Show();
        }
    }
}
