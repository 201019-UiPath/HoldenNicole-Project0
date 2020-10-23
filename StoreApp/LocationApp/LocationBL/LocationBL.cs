using System.Collections.Generic;
using LocationLib;
using LocationDB;
using System.Threading.Tasks;

namespace LocationBL
{
    public class LocationBL
    {
        IRepository repo = new FileRepo();
        public void AddLocation(Location newLocation){
            //add business logic
            //check if location name is unique
            //check if address is unique
            repo.AddLocationAsync(newHero);
        }
        public List<Location> GetAllLocations(){
            Task<List<Hero>> getLocations = repo.GetAllLocationsAsync();
            return getLocations.Result;
        }
    }
}
