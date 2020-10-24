using System;
using System.Collections.Generic;
namespace ManagerLib
{
    public class Manager
    {
        public int ManagerID {get; set;}
        public string ManagerName {get; set;}
        public int LocationID {get; set;}
        public static Dictionary<int,string> managerIDName = new Dictionary<int, string>();
        public static Dictionary<int,int> managerIDLocationID = new Dictionary<int, int>();
        public Manager(){
            managerIDName.Add(1, "BobRules");
            managerIDName.Add(2, "Bobasaurus");
            // add manager name to manager ID

            managerIDLocationID.Add(1, 1);
            managerIDLocationID.Add(2, 2);
            // add manager to manager location
        }
        public CheckManager(){
            string 
        }
    }
}
