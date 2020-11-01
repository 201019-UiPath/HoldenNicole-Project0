using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface ILocationMapper
    {
        Locations ParseLocation(Locations location);
        List<Locations> ParseLocation(List<Locations> location);
    }
}
