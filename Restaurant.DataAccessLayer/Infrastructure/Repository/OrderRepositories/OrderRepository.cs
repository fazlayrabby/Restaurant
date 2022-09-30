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
    //internal class OrderRepository
    //{
    //}

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Order order)
        {

            var orderDB = _dbContext.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
            if (orderDB != null)
            {
                
                orderDB.FirstName = order.FirstName;
                orderDB.LastName = order.LastName;
                orderDB.Product = order.Product;
                orderDB.State = order.State;
                orderDB.Date = order.Date;
                orderDB.OrderProduct = order.OrderProduct;
               

            }

        }
    }
}
