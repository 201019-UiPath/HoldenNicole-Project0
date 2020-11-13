using StoreDB.Entities;
using StoreDB.Models;

namespace StoreUI
{
    public interface IManagerMapper
    {
        Managers ParseManager(ManagerModel manager);
        ManagerModel ParseManager(Managers managers);
    }
}
