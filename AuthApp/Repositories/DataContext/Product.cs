using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class Product
    {
        public Product()
        {
            ClotheOfProduct = new HashSet<ClotheOfProduct>();
            FurnituresOfProduct = new HashSet<FurnituresOfProduct>();
            OrderedProduct = new HashSet<OrderedProduct>();
        }

        public string ProductCode { get; set; }
        public string Name { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ClotheOfProduct> ClotheOfProduct { get; set; }
        public virtual ICollection<FurnituresOfProduct> FurnituresOfProduct { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProduct { get; set; }
    }
}
