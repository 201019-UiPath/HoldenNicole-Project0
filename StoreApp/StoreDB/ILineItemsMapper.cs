using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB
{
    public interface ILineItemsMapper
    {
        LineItems ParseLineItem(LineItemModel lineItem);
        ICollection<LineItems> ParseLineItem(List<LineItemModel> lineItem);
        LineItemModel ParseLineItem(LineItems lineItem);
        List<LineItemModel> ParseLineItem(ICollection<LineItems> lineItem);
    }
}
