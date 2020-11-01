using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface IManagerMapper
    {
        Managers ParseManager(Managers manager);
        List<Managers> ParseManager(List<Managers> manager);
    }
}
