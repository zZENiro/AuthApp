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
        public Action<dtoPerson> Authenticated;

        private AuthenticationViewModel _authVM;

        public AuthenticationWindow(AccountsRepository accounts)
        {
            InitializeComponent();

            this.Closed += (s, e) =>
                Application.Current.Shutdown();

            _authVM = new AuthenticationViewModel(accounts);
            _authVM.Authenticated += user => Authenticated(user);
            _authVM.AuthenticationDenied += () => MessageBox.Show("Неправильный логин/пароль.");
            _authVM.Registrated += user => AlertRegistration(user);
            _authVM.RegistrationDenied += () => MessageBox.Show("Не удалось зарегестрироваться.");

            DataContext = _authVM;
        }

        private void AlertRegistration(dtoPerson user)
        {
            MessageBox.Show($"Вы зарегестрированы.\n" +
                            $"логин: {user.login}\n" +
                            $"пароль: {user.password}");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _authVM.Login = ((TextBox)sender).Text;
        }
    }
}
