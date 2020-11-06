namespace LocationLib
{
    public class InventoryService
    {
        private readonly DBRepo dBRepo;
        public ProductServices()
        {
            this.dBRepo = new DBRepo();
        }
        public List<Inventory> ViewAllProductsAtLocation(int id)
        {
            List<Inventory> viewAllProductsAtLocation = dBRepo.ViewAllProductsAtLocation(id);
            return viewAllProductsAtLocation;
        }
    }
}