using System;
using System.Collections.Generic;

namespace MedicalShop.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            Orders = new HashSet<Orders>();
        }

        public int Mid { get; set; }
        public string Mname { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Price { get; set; }
        public int QuantityRemaining { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
