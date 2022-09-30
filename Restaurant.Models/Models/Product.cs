﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

    }
}
