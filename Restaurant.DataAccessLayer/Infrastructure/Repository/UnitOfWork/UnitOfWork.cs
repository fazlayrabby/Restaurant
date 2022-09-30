using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccessLayer.Data;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IOrderRepositories;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IProductRepositories;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IUnitOfWork;
using Restaurant.DataAccessLayer.Infrastructure.Repository.OrderRepositories;
using Restaurant.DataAccessLayer.Infrastructure.Repository.ProductRepositories;
using Restaurant.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public IOrderRepository Order { get; private set; }
        public IProductRepository Product { get; private set; }

        public IOrderProductRepository OrderProduct { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Order = new OrderRepository(dbContext);
            Product = new ProductRepository(dbContext);
            OrderProduct = new OrderProductRepository(dbContext);

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
