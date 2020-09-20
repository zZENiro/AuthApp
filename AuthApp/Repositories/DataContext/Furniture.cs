using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class Furniture
    {
        public Furniture()
        {
            FurnitureItem = new HashSet<FurnitureItem>();
            FurnituresOfProduct = new HashSet<FurnituresOfProduct>();
        }

        public string FurnitureCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Width { get; set; }
        public double? Length { get; set; }
        public double? Weight { get; set; }
        public string ImageUrl { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<FurnitureItem> FurnitureItem { get; set; }
        public virtual ICollection<FurnituresOfProduct> FurnituresOfProduct { get; set; }
    }
}
