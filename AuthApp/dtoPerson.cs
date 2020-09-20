using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp
{

    public class dtoPerson
    {
        public string login { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public string userName { get; set; }
        public dtoRole role { get; set; }
        public object[] orderCustomer { get; set; }
        public object[] orderManager { get; set; }
    }

    public class dtoRole
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public object user { get; set; }
    }
}
