using StoreUI;
using StoreDB.Entities;
using System;
using System.Collections.Generic;

namespace ManagerLib
{
    public class ManagerSevices
    {
        private readonly DBRepo dBRepo;
        public ManagerSevices(DBRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }
        public void AddProductToLocation(int locationid, int productid, int quantity)
        {
            dBRepo.AddProductToLocation(locationid, productid, quantity);
        }
        public void DeleteProductAtLocation(int locationid, int productid, int quantity)
        {
            dBRepo.DeleteProductAtLocation(locationid, productid, quantity);
        }

        public Managers GetManagerByName(string managerUserName)
        {
            throw new NotImplementedException();
        }
    }
}
