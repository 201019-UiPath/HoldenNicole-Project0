using StoreUI.Entities;
using System.Collections.Generic;

namespace StoreUI
{
    public interface IManagerMapper
    {
        Managers ParseManager(Managers manager);
        List<Managers> ParseManager(List<Managers> manager);
    }
}
