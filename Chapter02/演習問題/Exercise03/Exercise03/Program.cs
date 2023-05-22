using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            IDictionary<string, int> amounts = null;
            var sales = new SalesCounter(@"data\Sales.csv");
            Console.Write("＊＊売上集計＊＊\n1：店舗別売り上げ\n2：商品カテゴリ別売り上げ\n>");
            int val = int.Parse(Console.ReadLine());
            
            if (val == 1) {
                amounts = AmountPerStore(sales);
            } else {
                amounts = AmountPerCategory(sales);
            }
            PrintAmount(amounts);
        }

        private static void PrintAmount(IDictionary<string,int> amounts) {
            foreach (var obj in amounts) {
                Console.WriteLine("{0}   \t{1:C}", obj.Key, obj.Value);
            }
        }

        private static IDictionary<string, int> AmountPerCategory(SalesCounter sales) {
            return sales.GetPerCategorySales();
        }

        private static IDictionary<string, int> AmountPerStore(SalesCounter sales) {
            return sales.GetPerStoreSales();
        }
    }
}
