﻿using ProiectV1.Models;
using ProiectV1.Models.Enums;
using ProiectV1.Repositories.Generic;

namespace ProiectV1.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetByCategory(ProductCategory category);
    }
    
}
