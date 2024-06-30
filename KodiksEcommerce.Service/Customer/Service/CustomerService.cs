using KodiksEcommerce.Service.Service;
using Microsoft.EntityFrameworkCore;

namespace KodiksEcommerce.Service.Customer.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly IService<Data.EntityFreamwork.Entities.Customer> _service;

        public CustomerService(IService<Data.EntityFreamwork.Entities.Customer> service)
        {
            _service = service;
        }

        public async Task<Data.EntityFreamwork.Entities.Customer> GetCustomerByIdAsync(int id)
        {
            var model = await _service.GetAll()
            .Where(customer => customer.Id == id).FirstOrDefaultAsync();
            return model;
        }

        public async Task<IEnumerable<Data.EntityFreamwork.Entities.Customer>> GetAllCustomersAsync()
        {
            var model = await _service.GetAll().ToListAsync();
            return model;
        }

        public async Task CreateCustomerAsync(Data.EntityFreamwork.Entities.Customer customer)
        {
             _service.Add(customer);
            await _service.SaveAsync();
        }

        public async Task UpdateCustomerAsync(Data.EntityFreamwork.Entities.Customer customer)
        {
            var entity = await _service.FindAsync(customer.Id);
            _service.Update(entity);
            await _service.SaveAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _service.FindAsync(id);
            if (customer != null)
            {
                _service.Delete(customer);
                await _service.SaveAsync();
            }   
        }

    }
}
