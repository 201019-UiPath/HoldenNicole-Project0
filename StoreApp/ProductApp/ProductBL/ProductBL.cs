using System.Collections.Generic;
using ProductLib;
using ProductDB;
using System.Threading.Tasks;

namespace ProductBL
{
    public class ProductBL
    {
        IRepository repo = new FileRepo();
        public void AddProduct(Product newProduct){
            repo.AddProductAsync(newProduct);
        }
        public List<ProductBL> GetAllProduct(){
            Task<List<Product>> getProducts = repo.GetAllProductsAsync();
            return getProducts.Result;
        }
    }
}
