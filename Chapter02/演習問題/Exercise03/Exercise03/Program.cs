using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            var sales = new SalesCounter(@"data\Sales.csv");
            Console.Write("＊＊売上集計＊＊\n1：店舗別売り上げ\n2：商品カテゴリ別売り上げ\n>");
            int val = int.Parse(Console.ReadLine());

            if (val == 1) {
                AmountPerStore(sales);
            } else if(val == 2) {
                AmountPerCategory(sales);
            } 
        }

        private static void AmountPerCategory(SalesCounter sales) {
            var amountPerCategory = sales.GetPerCategorySales();
            foreach (var obj in amountPerCategory) {
                Console.WriteLine("{0}\t{1:C}", obj.Key, obj.Value);
            }
        }

        private static void AmountPerStore(SalesCounter sales) {
            var amountPerStore = sales.GetPerStoreSales();
            foreach (var obj in amountPerStore) {
                Console.WriteLine("{0}  \t{1:C}", obj.Key, obj.Value);
            }
        }
    }
}
