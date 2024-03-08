using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    class DbConnection
    {
        public static string DBCon() 
        {
            string Str = "Data Source = DESKTOP-45M6VAU\\SQLEXPRESS;Initial Catalog = Inventory_Management_System;Integrated Security = true";
            return Str;
        }
    }
}
