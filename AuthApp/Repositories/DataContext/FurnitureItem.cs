using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class FurnitureItem
    {
        public int ItemId { get; set; }
        public string FurnitureCode { get; set; }
        public int Count { get; set; }

        public virtual Furniture FurnitureCodeNavigation { get; set; }
    }
}
