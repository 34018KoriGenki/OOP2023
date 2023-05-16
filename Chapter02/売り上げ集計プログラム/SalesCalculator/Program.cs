using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            SalesCounter sales = new SalesCounter(SalesCounter.ReadSales(@"data\Sales.csv"));
            Dictionary<string, int> amountPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountPerStore) {
                Console.WriteLine("{0}  \t{1:C}", obj.Key, obj.Value);
            }
        }
    }
}
