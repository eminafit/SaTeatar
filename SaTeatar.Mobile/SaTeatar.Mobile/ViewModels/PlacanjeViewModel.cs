using Acr.UserDialogs;
using SaTeatar.Mobile.Helpers;
using SaTeatar.Mobile.Models;
using SaTeatar.Mobile.Views;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace SaTeatar.Mobile.ViewModels
{
    class PlacanjeViewModel : BaseViewModel
    {
        private readonly APIService _narudzbaService = new APIService("narudzba");
        private readonly APIService _karteService = new APIService("karte");
        private readonly APIService _narudzbaStavkeService = new APIService("narudzbaStavke");

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public mNarudzba Narudzba { get; set; }

        public PlacanjeViewModel()
        {
            SubmitCommand = new Command(async () => await Plati());

        }

        public ICommand SubmitCommand { get; set; }

        private string StripeTestApiKey = "sk_test_51JNyRxCGG4akAYELQXXMQayAg3wwgEIH9srID9neI67oAexoag3TEfdoKUTanTc7s0rFfHdZnmjRWAcaH6LAeBAS00pTPF3fGM";

        private CreditCard _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private string _number;
        private string _cvc;

        mKupci user = PrijavljeniKupac.Kupac;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
        public string Cvc
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }
        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }
        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        public CreditCard CreditCardModel 
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }
        private async Task<string> CreateTokenAsync()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;

                var Tokenoptions = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = user.Ime + " " + user.Prezime,
                        AddressLine1 = "Ulica 1",
                        AddressLine2 = "2",
                        AddressCity = "Sarajevo",
                        AddressZip = "71000",
                        AddressState = "Ulica123",
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> MakePaymentAsync(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51JNyRxCGG4akAYELQXXMQayAg3wwgEIH9srID9neI67oAexoag3TEfdoKUTanTc7s0rFfHdZnmjRWAcaH6LAeBAS00pTPF3fGM";

                var options = new ChargeCreateOptions();

                options.Amount = Convert.ToInt64(Narudzba.Iznos) * 100; 
                options.Currency = "usd";
                options.Description = "opis";
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = user.Email.ToString();
                var service = new ChargeService();
                Charge charge = service.Create(options);
                Narudzba.PaymentId = charge.Id;
                await _narudzbaService.Update<mNarudzba>(Narudzba.NarudzbaId, Narudzba);
                UserDialogs.Instance.Alert("Uspjesno placanje!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(Narudzba.BrNarudzbe.ToString() + " (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        public async Task Plati()
        {
            var nar = await _narudzbaService.GetById<mNarudzba>(Narudzba.NarudzbaId);
            if (nar.PaymentId!=string.Empty)
            {
                await App.Current.MainPage.DisplayAlert("Informacija", "Vec ste kupili ovo!", "OK");
            }
            else
            {
                if (ExpMonth == null || ExpMonth == "" || ExpYear == null || ExpYear == "" || Number == null || Number == "" || Cvc == null || Cvc == "")
                {
                    UserDialogs.Instance.Alert("Trebate ispuniti sva polja!", "Placanje nije uspjelo", "OK");
                    return;
                }
                if (ExpMonth != null || ExpMonth != "" || ExpYear != null || ExpYear != "" || Number != null || Number != "" || Cvc != null || Cvc != "")
                {
                    if (!IsDigitsOnly(ExpMonth) || !IsDigitsOnly(ExpMonth) || !IsDigitsOnly(Number) || !IsDigitsOnly(Cvc))
                    {
                        UserDialogs.Instance.Alert("Ne mozete koristiti slova!", "Placanje nije uspjelo", "OK");
                        return;
                    }
                }
                CreditCardModel = new CreditCard();
                CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
                CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
                CreditCardModel.Number = Number;
                CreditCardModel.Cvc = Cvc;
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                try
                {
                    UserDialogs.Instance.ShowLoading("Placanje u toku ...");
                    //await Task.Run(async () =>
                    //{
                        var Token = CreateTokenAsync();
                        Console.Write(Narudzba.BrNarudzbe.ToString() + "Token :" + Token);
                        if (Token.ToString() != null)
                        {
                            IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Netacni podaci na kartici", null, "OK");
                        }
                    //});
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message, null, "OK");
                    Console.Write(Narudzba.BrNarudzbe.ToString() + ex.Message);
                }
                finally
                {
                    if (IsTransectionSuccess)
                    {
                        await _narudzbaService.Update<mNarudzba>(Narudzba.NarudzbaId, Narudzba);
                        var search = new rNarudzbaStavkeSearch() { NarudzbaId = Narudzba.NarudzbaId };
                        List<mNarudzbaStavke> nsl = await _narudzbaStavkeService.Get<List<mNarudzbaStavke>>(search);

                        foreach (var ns in nsl)
                        {
                            var karta = await _karteService.GetById<mKarta>(ns.KartaId);
                            karta.Placeno = true;
                            await _karteService.Update<mKarta>(karta.KartaId, karta);

                        }

                        Console.Write(Narudzba.NarudzbaId + "Uspjesno placanje");

                        UserDialogs.Instance.HideLoading();
                        await Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new KartePage()));


                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert("Nesto je poslo po zlu", "Placanje nije uspjelo", "OK");
                        Console.Write(Narudzba.NarudzbaId + "Payment Failure ");
                    }
                }
            }



        }
    }
}

