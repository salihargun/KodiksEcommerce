using KodiksEcommerce.Service.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IService<Data.EntityFreamwork.Entities.Product> _service;

        public ProductService(IService<Data.EntityFreamwork.Entities.Product> service)
        {
            _service = service;
        }

        public async Task<Data.EntityFreamwork.Entities.Product> GetProductByIdAsync(int id)
        {
            var model = await _service.GetAll()
            .Where(Product => Product.Id == id).FirstOrDefaultAsync();
            return model;
        }

        public async Task<IEnumerable<Data.EntityFreamwork.Entities.Product>> GetAllProductsAsync()
        {
            var model = await _service.GetAll().ToListAsync();
            return model;
        }

        public async Task CreateProductAsync(Data.EntityFreamwork.Entities.Product product)
        {
            _service.Add(product);
            await _service.SaveAsync();
        }

        public async Task UpdateProductAsync(Data.EntityFreamwork.Entities.Product product)
        {
            var entity = await _service.FindAsync(product.Id);
            _service.Update(entity);
            await _service.SaveAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _service.FindAsync(id);
            if (product != null)
            {
                _service.Delete(product);
                await _service.SaveAsync();
            }
        }
    }
}
