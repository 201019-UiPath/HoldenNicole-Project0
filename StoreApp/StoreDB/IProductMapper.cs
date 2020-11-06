using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface IProductMapper
    {
        Products ParseProducts(ProductModel product);
        ProductModel ParseProducts(Products product);
        ICollection<Products> ParseProducts(List<ProductModel> product);
        List<ProductModel> ParseProducts(ICollection<Products> product);
    }
}
