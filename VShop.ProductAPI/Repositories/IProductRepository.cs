﻿using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByID(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
