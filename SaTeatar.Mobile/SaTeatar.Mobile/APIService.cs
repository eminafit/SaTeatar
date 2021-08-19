using Flurl.Http;
using Flurl;
using SaTeatar.Model;
using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SaTeatar.Mobile.Views;
using SaTeatar.Model.Requests;

namespace SaTeatar.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;

#if DEBUG
        string _apiUrl = "http://localhost:54698";
#endif
#if RELEASE
        string _apiUrl = "http://mojsajt.com";

#endif

      //  public static mKorisnici TrenutniKorisnik { get; set; }

        public APIService(string route) //Korisnici, predstave..
        {
            _route = route;
        }


        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";
            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex) //when (ex.Call.HttpStatus == HttpStatusCode.Unauthorized)
            {
                if (ex.Call.HttpResponseMessage?.StatusCode == HttpStatusCode.Unauthorized)//.Response.ResponseMessage.StatusCode.Equals(401))
                {
                    
                    await Application.Current.MainPage.DisplayAlert("Greska", "Niste autentificirani", "OK");
                }
                throw;
            }

        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Recommend<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/Recommend/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {

                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
                //MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
                // MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greska", stringBuilder.ToString(), "OK");
                //MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<mKupci> Authenticate(rKupciAuth request)
        {
            try
            {
                var url = $"{_apiUrl}/kupci/Authenticate";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<mKupci>();
            }
            catch (FlurlHttpException)
            {
                return default;
            }
        }

        public async Task<mKupci> Registracija(rKupciInsert request)
        {
            try
            {
                var url = $"{_apiUrl}/kupci/Registracija";
                return await url.PostJsonAsync(request).ReceiveJson<mKupci>();
            }
            catch (FlurlHttpException)
            {
                return default;
            }
        }
    }
}
