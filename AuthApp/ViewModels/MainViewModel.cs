using AuthApp.DataContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private RoleViewModel _selectedRole;

        public MainViewModel()
        {
            Roles = new ObservableCollection<RoleViewModel>()
            {
                new AdminViewModel(),
                new UserViewModel()
            };

            SelectedRole = Roles.FirstOrDefault();
        }

        public ObservableCollection<RoleViewModel> Roles { get; set; }

        public RoleViewModel SelectedRole { get => _selectedRole; set => SetValue(ref _selectedRole, value); }
    }
}
