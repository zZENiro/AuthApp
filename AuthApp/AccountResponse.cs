using AuthApp.DataContext;

namespace AuthApp
{
    public class AccountResponse
    {
        private bool _authenticated;
        private dtoPerson _user;

        public AccountResponse(bool authenticated)
        {
            _authenticated = authenticated;
        }

        public string Message { get; set; }
        public bool Authenticated { get => _authenticated; set => _authenticated = value; }
        public dtoPerson User { get => _user; set => _user = value; }
    }
}