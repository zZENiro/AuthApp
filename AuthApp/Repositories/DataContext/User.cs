using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class User
    {
        public User()
        {
            OrderCustomer = new HashSet<Order>();
            OrderManager = new HashSet<Order>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> OrderCustomer { get; set; }
        public virtual ICollection<Order> OrderManager { get; set; }
    }
}
