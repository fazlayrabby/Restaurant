using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IOrderRepositories;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IProductRepositories;

namespace Restaurant.DataAccessLayer.Infrastructure.IRepository.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IOrderProductRepository OrderProduct { get; }
        void Save();
    }
}
