using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ILocationMapper
    {
        Locations ParseLocation(LocationModel location);
        ICollection<Locations> ParseLocation(List<LocationModel> location);
        List<LocationModel> ParseLocation(ICollection<Locations> location);
        LocationModel ParseLocation(Locations location);
    }
}
