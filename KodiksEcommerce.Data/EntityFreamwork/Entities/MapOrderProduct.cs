﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Data.EntityFreamwork.Entities
{
    public class MapOrderProduct
    {
        public int OrderId { get; set; }  
        public Order Order { get; set; }  

        public int ProductId { get; set; }  
        public Product Product { get; set; }  
    }

}
