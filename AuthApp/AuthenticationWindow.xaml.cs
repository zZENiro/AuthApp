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
using System.Windows.Input;

namespace AuthApp
{
    public partial class AuthenticationWindow : Window
    {
        public Action<dtoPerson> Authenticated;

        private AuthenticationViewModel _authVM;

        public AuthenticationWindow(AccountsRepository accounts)
        {
            InitializeComponent();

            Closed += (s, e) =>
                Application.Current.Shutdown();

            _authVM = new AuthenticationViewModel(accounts);
            _authVM.Authenticating += () => Mouse.OverrideCursor = Cursors.Wait;

            _authVM.Authenticated += user =>
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                Authenticated(user);
            };

            _authVM.AuthenticationDenied += () =>
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Неправильный логин/пароль.");
            };

            _authVM.Registrated += user =>
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                AlertRegistration(user);
            };

            _authVM.RegistrationDenied += () =>
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("Не удалось зарегестрироваться.");
            };

            DataContext = _authVM;
        }

        private void AlertRegistration(dtoPerson user)
        {
            MessageBox.Show($"Вы зарегестрированы.\n" +
                            $"логин: {user.login}\n" +
                            $"пароль: {user.password}");
        }
    }
}
