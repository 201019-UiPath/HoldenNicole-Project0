using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public interface ILocationMapper
    {
        Locations ParseLocation(Locations location);
        List<Locations> ParseLocation(List<Locations> location);
    }
}
