using System;
using System.Collections.Generic;

namespace MedicalShop.Models
{
    public partial class Orders
    {
        public int Oid { get; set; }
        public DateTime Dateoforder { get; set; }
        public int Mid { get; set; }
        public int Quantity { get; set; }
        public int Totalcost { get; set; }

        public virtual Medicine M { get; set; }
    }
}
