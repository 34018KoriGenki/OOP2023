using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            var sales = new SalesCounter(@"data\Sales.csv");
            var amountPerStore = sales.GetPerStoreSales();
            foreach (var obj in amountPerStore) {
                Console.WriteLine("{0}  \t{1:C}", obj.Key, obj.Value);
            }
        }
    }
}
