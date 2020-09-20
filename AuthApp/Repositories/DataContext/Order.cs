using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class Order
    {
        public Order()
        {
            OrderedProduct = new HashSet<OrderedProduct>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int StageId { get; set; }
        public string CustomerId { get; set; }
        public string ManagerId { get; set; }
        public decimal? Cost { get; set; }

        public virtual User Customer { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProduct { get; set; }
    }
}
