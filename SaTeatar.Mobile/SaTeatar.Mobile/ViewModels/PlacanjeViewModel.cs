using Acr.UserDialogs;
using SaTeatar.Mobile.Helpers;
using SaTeatar.Mobile.Models;
using SaTeatar.Model.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaTeatar.Mobile.ViewModels
{
    class PlacanjeViewModel : BaseViewModel
    {
        private readonly APIService _narudzbaService = new APIService("narudzba");
        private readonly APIService _karteService = new APIService("karte");
        //public PlacanjeViewModel (INavigation nav)
        //{
        //    this.Navigation = nav;
        //}

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public KorpaViewModel Narudzba { get; set; }

        public PlacanjeViewModel()
        {
            SubmitCommand = new Command(async () => await Plati());

        }

        private readonly INavigation Navigation;
        public ICommand SubmitCommand { get; set; }

     //   public MCourse Course { get; set; }

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
        public CreditCard CreditCardModel //
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

                options.Amount = Convert.ToInt64(Narudzba.Narudzba.Iznos) * 100; // Convert.ToInt64(Course.Price) * 100;
                options.Currency = "usd";
                options.Description = "opis";// Course.Name;
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = user.Email.ToString();
                var service = new ChargeService();
                Charge charge = service.Create(options);
                Narudzba.Narudzba.PaymentId = charge.Id;
                await _narudzbaService.Update<mNarudzba>(Narudzba.Narudzba.NarudzbaId, Narudzba.Narudzba);
                UserDialogs.Instance.Alert("Purchase was successful!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(/*Course.Name*/"narudzba" + " (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        public async Task Plati()
        {
            var nar = await _narudzbaService.GetById<mNarudzba>(Narudzba.Narudzba.NarudzbaId);
            if (nar.PaymentId!=string.Empty)
            {
                await App.Current.MainPage.DisplayAlert("Information", "You already bought this!", "OK");
            }
            else
            {
                if (ExpMonth == null || ExpMonth == "" || ExpYear == null || ExpYear == "" || Number == null || Number == "" || Cvc == null || Cvc == "")
                {
                    UserDialogs.Instance.Alert("You have to fill all fields!", "Payment failed", "OK");
                    return;
                }
                if (ExpMonth != null || ExpMonth != "" || ExpYear != null || ExpYear != "" || Number != null || Number != "" || Cvc != null || Cvc != "")
                {
                    if (!IsDigitsOnly(ExpMonth) || !IsDigitsOnly(ExpMonth) || !IsDigitsOnly(Number) || !IsDigitsOnly(Cvc))
                    {
                        UserDialogs.Instance.Alert("You can't use letters!", "Payment failed", "OK");
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
                    UserDialogs.Instance.ShowLoading("Payment processing ...");
                    //await Task.Run(async () =>
                    //{
                        var Token = CreateTokenAsync();
                        Console.Write(Narudzba.Narudzba.BrojNarudzbe + "Token :" + Token);
                        if (Token.ToString() != null)
                        {
                            IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Bad card credentials", null, "OK");
                        }
                    //});
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message, null, "OK");
                    Console.Write(Narudzba.Narudzba.BrojNarudzbe + ex.Message);
                }
                finally
                {
                    if (IsTransectionSuccess)
                    {
                       // Narudzba.Narudzba.PaymentId = "pribavi";

                        await _narudzbaService.Update<mNarudzba>(Narudzba.Narudzba.NarudzbaId, Narudzba.Narudzba);

                        foreach (var karta in  Narudzba.KarteList)
                        {
                            karta.Placeno = true;
                            await _karteService.Update<mKarta>(karta.KartaId, karta);
                        }

                        Console.Write(Narudzba.Narudzba.NarudzbaId + "Payment Successful");

                        UserDialogs.Instance.HideLoading();

                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                        Console.Write(Narudzba.Narudzba.NarudzbaId + "Payment Failure ");
                    }
                }
            }
        }
    }
}

