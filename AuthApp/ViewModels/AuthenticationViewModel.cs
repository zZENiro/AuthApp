using AuthApp.Repositories;
using AuthApp.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Windows;
using AuthApp.DataContext;

namespace AuthApp.ViewModels
{
    public class AuthenticationViewModel : BaseViewModel, IDataErrorInfo
    {
        AccountsRepository _accountsRepo;
        private string _login;
        private string _password;
        private string _error;
        private AccountManager _accountManager;
        private bool _isProcessing;

        public Action<dtoPerson> Authenticated;
        public Action AuthenticationDenied;
        public Action<dtoPerson> Registrated;
        public Action RegistrationDenied;
        public Action Authenticating;

        public AuthenticationViewModel(AccountsRepository repo)
        {
            _accountsRepo = repo;
            _accountManager = new AccountManager();

            _accountManager.AccessSucceed += resp => Authenticated?.Invoke(resp.User);
            _accountManager.AccessDenied += resp => AuthenticationDenied?.Invoke();
            _accountManager.RegistrationDenied += resp => RegistrationDenied?.Invoke();
            _accountManager.RegistrationSucceed += resp => Registrated?.Invoke(resp.User);
        }

        public string Error { get => _error; set => SetValue(ref _error, value); }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Login":
                        {
                            if (_login is null)
                                break;

                            if (_login.StartsWith(" ") ||
                                _login.Where(el => char.IsDigit(el)).Any() ||
                                _login.Contains(" "))
                                _error = "Логин не правильного формата";
                            else
                                _error = string.Empty;

                            break;
                        };
                    default:
                        _error = string.Empty;
                        break;
                }
                return Error;
            }
        }

        public string Login { get => _login; set => SetValue(ref _login, value); }
        public string Password { get => _password; set => SetValue(ref _password, value); }

        public ICommand AuthenticateCommand
        {
            get => new AuthenticateCommand(
                execute: async creds =>
                {
                    if (!string.IsNullOrEmpty(Error) || string.IsNullOrEmpty(Login))
                        MessageBox.Show("Некорректные входные данные");
                    else
                    {
                        Authenticating?.Invoke();
                        _isProcessing = true;
                        await _accountManager.AuthenticateAsync(_login, _password);
                        _isProcessing = false;
                    }
                },
                canExecute: prop => !_isProcessing
            );
        }

        public ICommand RegisterCommand
        {
            get => new RegisterCommand(
                    execute: async param =>
                    {
                        if (!string.IsNullOrEmpty(Error) || string.IsNullOrEmpty(Login))
                            MessageBox.Show("Некорректные входные данные");
                        else
                        {
                            Authenticating?.Invoke();
                            _isProcessing = true;
                            await _accountManager.RegistrateAsync(_login, _password);
                            _isProcessing = false;
                        }
                    },
                    canExecute: prop => !_isProcessing
                );
        }
    }
}
