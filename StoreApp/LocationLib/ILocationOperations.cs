using System;
using System.Collections.Generic;
using System.Text;

namespace LocationLib
{
    interface ILocationOperations
    {
        void CheckInventory();
        void GetInventory();
        void GetHistory();
    }
}
