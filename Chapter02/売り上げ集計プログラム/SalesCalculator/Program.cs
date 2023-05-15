using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    class Program {
        static void Main(string[] args) {   //エントリポイント
            SalesCounter sales = new SalesCounter(ReadSales(@"data\Sales.csv"));
            Dictionary<string,int> amountPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string,int> obj in amountPerStore) {
                Console.WriteLine("{0}  \t{1:C}", obj.Key, obj.Value);
            }
        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {  //スタブ
            
            //売り上げデータを格納する
            List<Sale> sales = new List<Sale>();
            
            //ファイルからすべてのデータを読み込む
            string[] lines = File.ReadAllLines(filePath);
            
            //すべての行から一行ずつ取り出す
            foreach (string line in lines) {
                
                //区切りで項目別に分ける
                string[] items = line.Split(',');
                
                //Saleインスタンスを生成
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                
                //Saleインスタンスをコレクションに追加
                sales.Add(sale);
            }
            return sales;
        }
    }
}
