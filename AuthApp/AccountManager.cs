using AuthApp.DataContext;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthApp
{
    public class AccountManager
    {
        public Action<AccountResponse> AccessSucceed;
        public Action<AccountResponse> AccessDenied;

        public Action<AccountResponse> RegistrationSucceed;
        public Action<AccountResponse> RegistrationDenied;

        public async Task AuthenticateAsync(string login, string password)
        {
            var client = new RestClient(new Uri("https://localhost:5001/api/Accounts/Authenticate"));
            var request = new RestRequest(Method.GET);

            var cookies = new CookieContainer();
            cookies.Add(new Cookie("login", login, "/", "localhost"));
            cookies.Add(new Cookie("password", password, "/", "localhost"));
            client.CookieContainer = cookies;

            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Accepted)
            {
                var user = JsonSerializer.Deserialize<dtoPerson>(resp.Content);
                AccessSucceed?.Invoke(new AccountResponse(authenticated: true) { User = user });
            }
            else
                AccessDenied?.Invoke(new AccountResponse(authenticated: false));
        }

        public async Task RegistrateAsync(string login, string password)
        {
            var client = new RestClient(new Uri("https://localhost:5001/api/Accounts/Registration"));
            var request = new RestRequest(Method.GET);

            var cookies = new CookieContainer();
            cookies.Add(new Cookie("login", login, "/", "localhost"));
            cookies.Add(new Cookie("password", password, "/", "localhost"));
            cookies.Add(new Cookie("username", "undefinded", "/", "localhost"));
            client.CookieContainer = cookies;

            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode == HttpStatusCode.Accepted || resp.StatusCode == HttpStatusCode.OK)
                RegistrationSucceed?.Invoke(new AccountResponse(authenticated: true)
                {
                    User = JsonSerializer.Deserialize<dtoPerson>(resp.Content)
                });
            else
                RegistrationDenied?.Invoke(new AccountResponse(authenticated: false));
        }
    }
}
