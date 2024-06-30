using KodiksEcommerce.Data.EntityFreamwork.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Service
{
    public interface IService<T> : IRepository<T> where T : class
    {
    }
}
