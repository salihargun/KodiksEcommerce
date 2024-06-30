﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Data.EntityFreamwork.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public ICollection<MapOrderProduct> OrderProducts { get; set; }  // Ürün birden fazla siparişte bulunabilir
    }

}
