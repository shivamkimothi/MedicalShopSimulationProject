using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClientApp.Models.ViewModel
{
    public class OrderQuantityViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }

    }
}
