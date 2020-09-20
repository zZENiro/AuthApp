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

        public async Task AuthenticateAsync(string login, string password)
        {
            var client = new RestClient(new Uri("https://localhost:5001/api/Accounts/Authenticate"));
            var request = new RestRequest(Method.GET);

            var cookies = new CookieContainer();
            cookies.Add(new Cookie("login", login, "/", "localhost"));
            cookies.Add(new Cookie("password", password, "/", "localhost"));
            client.CookieContainer = cookies;

            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode == HttpStatusCode.OK)
                AccessSucceed?.Invoke(new AccountResponse(authenticated: true)
                {
                    User = JsonSerializer.Deserialize<User>(resp.Content)
                });
            else
                AccessDenied?.Invoke(new AccountResponse(authenticated: false));
        }

        public async Task RegistrateAsync(string login, string password)
        {
            var client = new RestClient(new Uri("https://localhost:5001/api/Accounts/Registrate"));
            var request = new RestRequest(Method.POST);
            client.CookieContainer.Add(new Cookie("login", login, "/", "localhost"));
            client.CookieContainer.Add(new Cookie("password", password, "/", "localhost"));
            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode == HttpStatusCode.OK)
                AccessSucceed?.Invoke(new AccountResponse(authenticated: true) { User = JsonSerializer.Deserialize<User>(resp.Content) });

            AccessDenied?.Invoke(new AccountResponse(authenticated: false));
        }
    }
}
