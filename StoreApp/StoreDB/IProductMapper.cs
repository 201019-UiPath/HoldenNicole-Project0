using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB
{
    public interface IProductMapper
    {
        Products ParseProducts(ProductModel product);
        ProductModel ParseProducts(Products product);
        ICollection<Products> ParseProducts(List<ProductModel> product);
        List<ProductModel> ParseProducts(ICollection<Products> product);
        // ProductModel ParseProduct(IQueryable<Products> queryables);
    }
}
