using KodiksEcommerce.Data.EntityFreamwork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Product.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Data.EntityFreamwork.Entities.Product>> GetAllProductsAsync();
        Task<Data.EntityFreamwork.Entities.Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Data.EntityFreamwork.Entities.Product product);
        Task UpdateProductAsync(Data.EntityFreamwork.Entities.Product product);
        Task DeleteProductAsync(int id);
    }
}
