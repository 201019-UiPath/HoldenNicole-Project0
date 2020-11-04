using System.Collections.Generic;
using StoreUI.Entities;

namespace StoreUI
{
    public interface IManagerMapper
    {
        Managers ParseManager(Managers manager);
        List<Managers> ParseManager(List<Managers> manager);
    }
}
