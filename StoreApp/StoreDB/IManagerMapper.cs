using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    public interface IManagerMapper
    {
        Managers ParseManager(ManagerModel manager);
        ManagerModel ParseManager(Managers managers);
    }
}
