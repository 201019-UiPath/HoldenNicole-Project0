using System.Collections.Generic;
using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI
{
    public interface IManagerMapper
    {
        Managers ParseManager(ManagerModel manager);
        ManagerModel ParseManager(Managers managers);
        List<Managers> ParseManager(ICollection<Managers> manager);
        ICollection<Managers> ParseManager(List<Managers> managers);
    }
}
