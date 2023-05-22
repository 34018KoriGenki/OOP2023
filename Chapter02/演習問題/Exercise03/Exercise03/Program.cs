using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            IDictionary<string,int> amounts = new Dictionary<string , int>();
            var sales = new SalesCounter(@"data\Sales.csv");
            Console.WriteLine("＊＊売上集計＊＊");
            Console.WriteLine("1：店舗別売り上げ");
            Console.WriteLine("2：商品カテゴリ別売り上げ");
            Console.Write(">");
            int val = int.Parse(Console.ReadLine());
            
            if (val == 1) {
                amounts = AmountPerStore(sales);
            } else if(val == 2){
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
