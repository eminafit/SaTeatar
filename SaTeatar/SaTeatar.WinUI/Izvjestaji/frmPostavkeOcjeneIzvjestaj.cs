using SaTeatar.Model.Models;
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
    public partial class frmPostavkeOcjeneIzvjestaj : Form
    {
        private readonly APIService _pozoristaService = new APIService("pozorista");
        private readonly APIService _ocjeneService = new APIService("ocjene");
        private readonly APIService _predstavaService = new APIService("predstava");
        private readonly APIService _izvodjenjaService = new APIService("izvodjenja");
        public frmPostavkeOcjeneIzvjestaj()
        {
            InitializeComponent();
        }

        private async void frmPostavkeOcjeneIzvjestaj_Load(object sender, EventArgs e)
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

        public class dtoPO
        {
            public string PozoristeNaziv { get; set; }
            public int PozoristeId { get; set; }

            public List<PredstavaOcjene> ListaPredstavaOcjena { get; set; }
        }


        public class PredstavaOcjene
        {
            public int PredstavaId { get; set; }
            public string PredstavaNaziv { get; set; }
            public List<int> ListaOcjena { get; set; }
            public double ProsjecnaOcjena { get; set; }
            public int PozoristeId { get; set; }
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var dtobj = new dtoPO();
                List<PredstavaOcjene> listPO = new List<PredstavaOcjene>();

                var ocjene = await _ocjeneService.Get<List<mOcjene>>(null);
                var ocjenjenePredstaveIds = ocjene.Select(x => x.PredstavaId).Distinct().ToList();

                var predstave = await _predstavaService.Get<List<mPredstave>>(null);
                foreach (var item in predstave)
                {
                    if (ocjenjenePredstaveIds.Contains(item.PredstavaId))
                    {
                        listPO.Add(new PredstavaOcjene()
                        {
                            PredstavaId = item.PredstavaId,
                            PredstavaNaziv = item.Naziv,
                            ListaOcjena = new List<int>(),
                            ProsjecnaOcjena = 0,
                            PozoristeId = 0
                        });
                    }
                }

                foreach (var o in ocjene)
                {
                    foreach (var p in listPO)
                    {
                        if (o.PredstavaId == p.PredstavaId)
                        {
                            p.ListaOcjena.Add(o.Ocjena);
                        }
                    }
                }

                foreach (var item in listPO)
                {
                    item.ProsjecnaOcjena = item.ListaOcjena.Average();
                }

                listPO.Sort((y, x) => x.ProsjecnaOcjena.CompareTo(y.ProsjecnaOcjena));

                //razvrstat po pozoristu
                var izvodjenja = await _izvodjenjaService.Get<List<mIzvodjenja>>(null);

                foreach (var po in listPO)
                {
                    foreach (var item in izvodjenja)
                    {
                        if (po.PredstavaId == item.PredstavaId)
                        //pod pretpostavkom da se predstava uvijek izvodi u istom pozoristu
                        // + ce prepisivati za svako izvodjenje.. :/ 
                        {
                            po.PozoristeId = item.PozoristeId;
                        }
                    }
                }

                var selectedPozoristeId = cmbPozorista.SelectedValue.ToString();

                var konacna = new List<PredstavaOcjene>();

                if (int.TryParse(selectedPozoristeId, out int pid))
                {
                    konacna = listPO.Where(x => x.PozoristeId == pid).ToList();
                    var pozoriste = await _pozoristaService.GetById<mPozorista>(pid);
                    dtobj.PozoristeId = pozoriste.PozoristeId;
                    dtobj.PozoristeNaziv = pozoriste.Naziv;
                }

                dtobj.ListaPredstavaOcjena = new List<PredstavaOcjene>();
                dtobj.ListaPredstavaOcjena = konacna;
                // var br = konacna.Count();
                frmOcjeneIzvjestaj frm = new frmOcjeneIzvjestaj(dtobj);
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
    }
}
