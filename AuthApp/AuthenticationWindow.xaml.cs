using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AuthApp.Repositories;
using AuthApp.DataContext;
using AuthApp.ViewModels;

namespace AuthApp
{
    public partial class AuthenticationWindow : Window
    {
        public Action<User> Authenticated;

        private AuthenticationViewModel _authVM;

        public AuthenticationWindow(AccountsRepository accounts)
        {
            InitializeComponent();

            this.Closed += (s, e) =>
                Application.Current.Shutdown();

            _authVM = new AuthenticationViewModel(accounts);
            _authVM.Authenticated += user => Authenticated(user);
            _authVM.DeniedAuthenitacionAction += () => MessageBox.Show("Неправильный логин/пароль");
            _authVM.Registrated += user => AlertRegistration(user);

            DataContext = _authVM;
        }

        private void AlertRegistration(User user)
        {
            MessageBox.Show($"Вы зарегестрированы.\n" +
                            $"логин: {user.Login}\n" +
                            $"пароль: {user.Password}");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _authVM.Login = ((TextBox)sender).Text;
        }
    }
}
