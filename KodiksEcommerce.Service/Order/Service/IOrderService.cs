using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Order.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Data.EntityFreamwork.Entities.Order>> GetAllOrdersAsync();
        Task<Data.EntityFreamwork.Entities.Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Data.EntityFreamwork.Entities.Order order);
        Task UpdateOrderAsync(Data.EntityFreamwork.Entities.Order order);
        Task DeleteOrderAsync(int id);
    }
}
