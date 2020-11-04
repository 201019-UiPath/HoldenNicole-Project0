using StoreUI.Entities;
using System.Collections.Generic;

namespace StoreUI
{
    public interface ILocationMapper
    {
        Locations ParseLocation(Locations location);
        List<Locations> ParseLocation(List<Locations> location);
    }
}
