using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Data.EntityFreamwork.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public ICollection<MapOrderProduct> OrderProducts { get; set; }  // Siparişin birden fazla ürünü olabilir
    }
}
