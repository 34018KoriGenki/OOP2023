using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            var sales = new SalesCounter(@"data\Sales.csv");
            var amountPerStore = sales.GetPerStoreSales();
            foreach (var obj in amountPerStore) {
                Console.WriteLine("{0}  \t{1:C}", obj.Key, obj.Value);
            }

            var amountPerCategory = sales.GetPerCategorySales();
            foreach (var obj in amountPerCategory) {
                Console.WriteLine("{0}\t{1:C}", obj.Key, obj.Value);
            }
        }
    }
}
