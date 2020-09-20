using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.ViewModels.Commands
{
    public class RegisterCommand : AuthenticateCommand
    {
        public RegisterCommand(Action<object> execute, Predicate<object> canExecute = null) 
            : base(execute, canExecute)
        {

        }
    }
}
