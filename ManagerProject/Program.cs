using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=AdoNetMarket;Integrated Security=True;Encrypt=False";

            DataAccess ds = new DataAccess();
            ds.InserItem(connectionString);
        }
    }
}
