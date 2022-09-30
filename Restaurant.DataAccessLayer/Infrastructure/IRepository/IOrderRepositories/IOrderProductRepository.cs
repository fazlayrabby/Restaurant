﻿using Restaurant.DataAccessLayer.Infrastructure.IRepository.IUnitOfWork;
using Restaurant.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.Infrastructure.IRepository.IOrderRepositories
{
    public interface IOrderProductRepository : IRepository<OrderProduct>
    {
        void Update(OrderProduct orderProduct);
    }
}
