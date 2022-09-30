using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccessLayer.Data;
using Restaurant.DataAccessLayer.Infrastructure.IRepository.IProductRepositories;
using Restaurant.DataAccessLayer.Infrastructure.Repository.UnitOfWork;
using Restaurant.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.Infrastructure.Repository.ProductRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Product product)
        {
            var productDB = _dbContext.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (productDB != null)
            {
                productDB.ProductName = product.ProductName;
                productDB.ProductPrice = product.ProductPrice;
                productDB.Stock = product.Stock;
                productDB.ProductImage = product.ProductImage;

            }
        }
    }
}
