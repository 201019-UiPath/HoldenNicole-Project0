using System.Collections.Generic;
using HeroesLib;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace ProductDB
{
    public class ProductFileRepo : IProductRepository
    {
        string filepath = "StoreApp/ProductApp/ProductDB/ProductDataLocation/Products.txt";
        /// <summary>
        /// adds product to file
        /// </summary>
        /// <param name="product"></param>
        public async void AddProductAsync(Product product){
            using(FileStream fs = File.Create(filepath)){
                await JsonSerializer.SerializeAsync(fs,product);
            }
        }
        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProductsAsync(){
            List<Product> allProducts = new List<Product>();
            using(FileStream fs = File.OpenRead(filepath)){
                allProducts.Add(await JsonSerializer.DeserializeAsync<Product>(fs));
            }
            return allProducts;
        }
    }
}
