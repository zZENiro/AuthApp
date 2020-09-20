using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class OrderedProduct
    {
        public int OrderId { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
