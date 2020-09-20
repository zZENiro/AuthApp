using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class ClotheItem
    {
        public int ItemId { get; set; }
        public string ClothCode { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }

        public virtual Clothe ClothCodeNavigation { get; set; }
    }
}
