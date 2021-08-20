using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    class PreporucenePredstaveViewModel : BaseViewModel
    {
        private readonly APIService _kupciService = new APIService("kupci");
        private readonly APIService _predstaveService = new APIService("predstava");
        private readonly APIService _tipovipredstavaService = new APIService("tipoviPredstava");
        private readonly APIService _predstaveDjelatniciService = new APIService("PredstaveDjelatnici");
        private readonly APIService _vrstedjelatnikaService = new APIService("vrsteDjelatnika");

        public PreporucenePredstaveViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<PreporucenePredstaveClass> PreporucenePredstave { get; set; } = new ObservableCollection<PreporucenePredstaveClass>();

        public class PreporucenePredstaveClass
        {
            public int PredstavaId { get; set; }
            public string Naziv { get; set; }
            public int TipId { get; set; }
            public string Tip { get; set; }
            public string Opis { get; set; }
            public byte[] Slika { get; set; }
            public string GlumciStr { get; set; }
            public string Rezija { get; set; }

        }

        public ICommand InitCommand { get; set; }


        bool _nemaPredstava = false;
        public bool NemaPredstava
        {
            get { return _nemaPredstava; }
            set { SetProperty(ref _nemaPredstava, value); }
        }

        string _poruka = string.Empty;
        public string Poruka
        {
            get { return _poruka; }
            set { SetProperty(ref _poruka, value); }
        }

        public async Task Init()
        {
            NemaPredstava = true;
            var search = new rKupciSearch() { KorisnickoIme = APIService.Username };
            var kupci = await _kupciService.Get<List<mKupci>>(search);
            var idkupca = kupci[0].KupacId;

            List<mPredstave> predstave = await _predstaveService.Recommend<List<mPredstave>>(idkupca);
            PreporucenePredstave.Clear();

            if (predstave.Count>0)
            {
                NemaPredstava = false;
                foreach (var item in predstave)
                {
                    var tip = await _tipovipredstavaService.GetById<mTipoviPredstava>(item.TipPredstaveId);

                    var searchg = new rPredstaveDjelatnicSearch() { PredstavaId = item.PredstavaId };
                    var listaglumaca = await _predstaveDjelatniciService.Get<List<mPredstaveDjelatnici>>(searchg);
                    string lgstr = "";
                    string rezija = "";
                    foreach (var g in listaglumaca)
                    {
                        if (g.Djelatnik.VrstaDjelatnikaId==2)
                        {
                            lgstr += $"{g.DjelatnikIme} {g.DjelatnikPrezime}\n";
                        }
                        else
                        {
                            rezija = $"{g.DjelatnikIme} {g.DjelatnikPrezime}";
                        }
                    }

                    PreporucenePredstave.Add(new PreporucenePredstaveClass()
                    {
                        PredstavaId = item.PredstavaId,
                        Naziv = item.Naziv,
                        Opis = item.Opis,
                        TipId = item.TipPredstaveId,
                        Tip = tip.Naziv.ToUpper(),
                        GlumciStr =lgstr,
                        Slika = item.Slika,
                        Rezija=rezija
                        
                    }) ;
                }


            }
            else
            {
                Poruka = "Niste ocijenili dovoljno predstava da bi vam mogli dati preporuke koje predstave da pogledate.";
            }



        }

    }
}
