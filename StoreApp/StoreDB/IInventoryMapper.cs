using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    /// <summary>
    /// mapping inventory model and entity
    /// </summary>
    public interface IInventoryMapper
    {
        Inventory ParseInventory(InventoryModel inventory);
        ICollection<Inventory> ParseInventory(List<InventoryModel> inventory);
        InventoryModel ParseInventory(Inventory inventory);
        List<InventoryModel> ParseInventory(ICollection<Inventory> inventory);
    }
}
