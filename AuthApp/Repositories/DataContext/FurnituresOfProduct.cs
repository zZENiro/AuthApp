using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class FurnituresOfProduct
    {
        public string FurnitureCode { get; set; }
        public string ProductCode { get; set; }
        public string Placement { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public int? Scale { get; set; }
        public int Count { get; set; }

        public virtual Furniture FurnitureCodeNavigation { get; set; }
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
