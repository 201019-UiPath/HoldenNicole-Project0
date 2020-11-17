using StoreDB.Models;
using StoreUI;
using System;
using System.Collections.Generic;

namespace LocationLib
{
    public class ProductServices : IProductServices
    {
        private readonly DBRepo dBRepo;
        public ProductServices(DBRepo repo)
        {
            this.dBRepo = repo;
        }
        public List<ProductModel> ViewAllProductsAtLocationSortByIDPriceLowToHigh(int id)
        {
            List<InventoryModel> viewAllInventoryAtLocation = dBRepo.ViewAllInventoryAtLocationSortByID(id);
            List<ProductModel> ViewAllProducts = new List<ProductModel>();
            foreach (var i in viewAllInventoryAtLocation)
            {
                int ID = i.productID;
                ProductModel product = dBRepo.GetProductByID(ID);
                ViewAllProducts.Add(product);
            }
            return ViewAllProducts;
        }
        public List<ProductModel> ViewAllProductsAtLocationSortByIDPriceHighToLow(int id)
        {
            List<InventoryModel> viewAllInventoryAtLocation = dBRepo.ViewAllInventoryAtLocationSortByID(id);
            List<ProductModel> ViewAllProducts = new List<ProductModel>();
            foreach (var i in viewAllInventoryAtLocation)
            {
                int ID = i.productID;
                ProductModel product = dBRepo.GetProductByID(ID);
                ViewAllProducts.Add(product);
            }
            return ViewAllProducts;
        }

        public ProductModel GetProductByID(int iD)
        {
            ProductModel product = dBRepo.GetProductByID(iD);
            return product;
        }
    }
}