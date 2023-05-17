using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    public class SalesCounter {

        private IEnumerable<Sale> _sales;

        //コンストラクタ
        public SalesCounter(string filePath) {
            _sales = ReadSales(filePath);
        }

        //店舗別売り上げを求める
        public IDictionary<string, int> GetPerStoreSales() {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount; //店名が既に存在する(売り上げ加算)
                else
                    dict[sale.ShopName] = sale.Amount;  //店名が存在しない(新規格納)
            }
            return dict;
        }

        public IDictionary<string, int> GetPerCategorySales() {
            var dict = new SortedDictionary<string, int>();
            foreach (var sale in _sales) {
                if (dict.ContainsKey(sale.ProductCategory))
                    dict[sale.ProductCategory] += sale.Amount; //店名が既に存在する(売り上げ加算)
                else
                    dict[sale.ProductCategory] = sale.Amount;  //店名が存在しない(新規格納)
            }
            return dict;
        }
        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        private static IEnumerable<Sale> ReadSales(string filePath) {  //スタブ

            //売り上げデータを格納する
            var sales = new List<Sale>();

            //ファイルからすべてのデータを読み込む
            var lines = File.ReadAllLines(filePath);

            //すべての行から一行ずつ取り出す
            foreach (var line in lines) {

                //区切りで項目別に分ける
                var items = line.Split(',');

                //Saleインスタンスを生成
                var sale = new Sale {
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
