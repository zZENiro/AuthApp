using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.ViewModels
{
    public abstract class RoleViewModel : BaseViewModel 
    {
        protected string _name;

        public RoleViewModel()
        {
            _name = "Main View Model";
        }

        public virtual string Name { get => _name; set => SetValue(ref _name, value); }
    }

    public class AdminViewModel : RoleViewModel
    {
        public AdminViewModel()
        {
            _name = "Admin View Model";
        }

        public override string Name { get => _name; set => SetValue(ref _name, value); }
    }

    public class UserViewModel : RoleViewModel
    {
        public UserViewModel()
        {
            _name = "User View Model";
        }

        public override string Name { get => _name; set => SetValue(ref _name, value); }
    }
}
