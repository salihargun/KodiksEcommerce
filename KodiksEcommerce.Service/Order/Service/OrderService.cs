using KodiksEcommerce.Service.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IService<Data.EntityFreamwork.Entities.Order> _service;

        public OrderService(IService<Data.EntityFreamwork.Entities.Order> service)
        {
            _service = service;
        }

        public async Task<Data.EntityFreamwork.Entities.Order> GetOrderByIdAsync(int id)
        {
            var model = await _service.GetAll()
            .Where(order => order.Id == id).FirstOrDefaultAsync();
            return model;
        }

        public async Task<IEnumerable<Data.EntityFreamwork.Entities.Order>> GetAllOrdersAsync()
        {
            var model = await _service.GetAll().ToListAsync();
            return model;
        }

        public async Task CreateOrderAsync(Data.EntityFreamwork.Entities.Order order)
        {
            _service.Add(order);
            await _service.SaveAsync();
        }

        public async Task UpdateOrderAsync(Data.EntityFreamwork.Entities.Order order)
        {
            var entity = await _service.FindAsync(order.Id);
            _service.Update(entity);
            await _service.SaveAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _service.FindAsync(id);
            if (order != null)
            {
                _service.Delete(order);
                await _service.SaveAsync();
            }
        }
    }
}
