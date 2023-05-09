using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    class Program {
        static void Main(string[] args) {

            #region P26のサンプルプログラム
            //インスタンスの生成
            //Product karinto = new Product(123, "かりんとう", 180);
            //Product daifuku = new Product(235, "大福もち", 160);

            //Console.WriteLine("かりんとうの税込価格：" + karinto.GetPriceIncludingTax());
            //Console.WriteLine("大福もちの税込価格：" + daifuku.GetPriceIncludingTax());
            #endregion

            #region 演習1
            //DateTime date = new DateTime(2023, 5, 8);
            DateTime date = DateTime.Today;

            Console.WriteLine("今日の日付："
                + date.Year + "年"
                + date.Month + "月"
                + date.Day + "日");

            //10日後を求める
            Console.WriteLine("10日後："
                + date.AddDays(10).Year + "年"
                + date.AddDays(10).Month + "月"
                + date.AddDays(10).Day + "日");
            Console.WriteLine("10日前："
                + date.AddDays(-10).Year + "年"
                + date.AddDays(-10).Month + "月"
                + date.AddDays(-10).Day + "日");
            #endregion


            #region 演習2
            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int birthYear = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int birthMonth = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int birthDay = int.Parse(Console.ReadLine());

            DateTime birth = new DateTime(birthYear, birthMonth, birthDay);
            TimeSpan interval = DateTime.Today - birth;

            Console.WriteLine("あなたは生まれてから今日まで" + interval.Days + "日目です。");
            #endregion


            #region 演習3
            string[] week = { "日", "月", "火", "水", "木", "金", "土" };

            Console.WriteLine("あなたは" + week[(int)birth.DayOfWeek] + "曜日に生まれました。");
            #endregion
        }
    }
}
