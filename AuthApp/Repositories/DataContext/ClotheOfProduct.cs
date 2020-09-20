using System;
using System.Collections.Generic;

namespace AuthApp.DataContext
{
    public partial class ClotheOfProduct
    {
        public string ClothCode { get; set; }
        public string ProductCode { get; set; }

        public virtual Clothe ClothCodeNavigation { get; set; }
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
