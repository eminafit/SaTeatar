using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using SaTeatar.Model;
using SaTeatar.Model.Models;

namespace SaTeatar.WinUI
{
    public class APIService
    {
        private string _route = null;

        public static string Username { get; set; }
        public static string Password { get; set; }

        public static mKorisnici TrenutniKorisnik { get; set; }

        public APIService(string route) //Korisnici, predstave..
        {
            _route = route;
        }

        //
        //public async Task<T> Auth<T>()
        //{
        //    var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

        //    return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

        //    //try
        //    //{
        //    //    return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        //    //}
        //    //catch (FlurlHttpException ex)
        //    //{
        //    //    if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
        //    //    {
        //    //        MessageBox.Show("Pogrešan username ili password");
        //    //    }
        //    //    throw;
        //    //}
        //}

        //

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }        

        public async Task<T> GetById <T> (object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert <T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Delete<T>(object id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
