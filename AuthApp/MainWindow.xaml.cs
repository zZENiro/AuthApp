using AuthApp.DataContext;
using AuthApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthApp
{
    public partial class MainWindow : Window
    {
        DesignersShopDbContext _context;
        AuthenticationWindow _authWindow;
        dtoRole _role;

        public MainWindow()
        {
            this.Visibility = Visibility.Hidden;
            this.IsVisibleChanged += (s, e) => _authWindow.Visibility = Visibility.Collapsed;
            this.Closed += (s, e) => Application.Current.Shutdown();

            _context = new DesignersShopDbContext();

            _authWindow = new AuthenticationWindow(new AccountsRepository(_context));
            _authWindow.Show();

            _authWindow.Authenticated += (user) =>
            {
                InitializeComponent();
                this.Visibility = Visibility.Visible;
                _role = ((dtoPerson)user).role;
            };
        }
    }
}
