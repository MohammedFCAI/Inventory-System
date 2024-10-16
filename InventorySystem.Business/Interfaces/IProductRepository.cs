﻿using InventorySystem.Data.Entities;

namespace InventorySystem.Business.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        public Product GetByIdWithInclude(int id);
    }
}
