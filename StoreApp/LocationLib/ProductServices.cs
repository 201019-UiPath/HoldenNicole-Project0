using System.Collections.Generic;
using StoreUI;
using StoreUI.Entities;

namespace LocationLib
{
    public class ProductServices
    {
        private DBRepo dBRepo;
        private readonly ixdssaucContext context;
        private readonly IMapper mapper;
        public ProductServices(DBRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
        public List<Products> ViewAllProductsByItem(string item)
        {
            List<Products> viewAllProductsByItem = dBRepo.ViewAllProductsByItem(item);
            return viewAllProductsByItem;
        }
        public List<Products> ViewAllProductsByAthlete(string athlete)
        {
            List<Products> viewAllProductsByAthlete = dBRepo.ViewAllProductsByAthlete(athlete);
            return viewAllProductsByAthlete;
        }
        public List<Products> ViewAllProductsBySport(string sport)
        {
            List<Products> viewAllProductsBySport = dBRepo.ViewAllProductsBySport(sport);
            return viewAllProductsBySport;
        }
        public List<Products> ViewAllProductsAtLocationGroupByAthlete(int id)
        {
            List<Products> viewAllProductsAtLocationGroupByAthlete = dBRepo.ViewAllProductsAtLocationGroupByAthlete(id);
            return viewAllProductsAtLocationGroupByAthlete;
        }
        public List<Products> ViewAllProductsAtLocationGroupByItem(int id)
        {
            List<Products> viewAllProductsAtLocationGroupByItem = dBRepo.ViewAllProductsAtLocationGroupByItem(id);
            return viewAllProductsAtLocationGroupByItem;
        }
        public List<Products> ViewAllProductsAtLocationGroupBySport(int id)
        {
            List<Products> viewAllProductsAtLocationGroupBySport = dBRepo.ViewAllProductsAtLocationGroupBySport(id);
            return viewAllProductsAtLocationGroupBySport;
        }
    }
}