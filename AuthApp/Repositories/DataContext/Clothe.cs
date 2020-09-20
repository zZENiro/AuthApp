using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class Clothe
    {
        public Clothe()
        {
            ClotheItem = new HashSet<ClotheItem>();
            ClotheOfProduct = new HashSet<ClotheOfProduct>();
        }

        public string ClothCode { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Pattern { get; set; }
        public string ImageUrl { get; set; }
        public string Composition { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<ClotheItem> ClotheItem { get; set; }
        public virtual ICollection<ClotheOfProduct> ClotheOfProduct { get; set; }
    }
}
