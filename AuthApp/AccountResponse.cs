using AuthApp.DataContext;

namespace AuthApp
{
    public class AccountResponse
    {
        private bool _authenticated;
        private User _user;

        public AccountResponse(bool authenticated)
        {
            _authenticated = authenticated;
        }

        public bool Authenticated { get => _authenticated; set => _authenticated = value; }
        public User User { get => _user; set => _user = value; }
    }
}