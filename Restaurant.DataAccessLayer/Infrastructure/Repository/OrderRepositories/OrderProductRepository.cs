using Restaurant.DataAccessLayer.Data;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IOrderRepositories;
using Restaurant.DataAccessLayer.Infrastructure.Repository.UnitOfWork;
using Restaurant.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.Infrastructure.Repository.OrderRepositories
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        private ApplicationDbContext _dbContext;
        public OrderProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(OrderProduct orderProduct)
        {

            var orderDB = _dbContext.OrderProducts.FirstOrDefault(x => x.OrderId == orderProduct.OrderId);
            if (orderDB != null)
            {
                



            }

        }

        
    }
}
