using KodiksEcommerce.Data.EntityFreamwork.Entities;

namespace KodiksEcommerce.Service.Customer.Repository
{
    public interface ICustomerService
    {
        Task<IEnumerable<Data.EntityFreamwork.Entities.Customer>> GetAllCustomersAsync();
        Task<Data.EntityFreamwork.Entities.Customer> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(Data.EntityFreamwork.Entities.Customer customer);
        Task UpdateCustomerAsync(Data.EntityFreamwork.Entities.Customer customer);
        Task DeleteCustomerAsync(int id);

    }
}
