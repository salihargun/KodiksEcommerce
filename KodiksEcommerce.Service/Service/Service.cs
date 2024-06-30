using KodiksEcommerce.Data;
using KodiksEcommerce.Data.EntityFreamwork.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiksEcommerce.Service.Service
{
    public class Service<T> : Repository<T>, IService<T> where T : class, new()
    {
        public Service(Context context) : base(context)
        {
        }
    }
}
