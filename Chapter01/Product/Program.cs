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

            Console.WriteLine("今日の日付：" + date.Year + "年" + date.Month + "月" + date.Day + "日");

            //10日後を求める
            Console.WriteLine("10日後：" + date.AddDays(10).Year + "年" + date.AddDays(10).Month + "月" + date.AddDays(10).Day + "日");
            DateTime daysBefore10 = date.AddDays(-10);
            Console.WriteLine("10日前：" + date.AddDays(-10).Year + "年" + date.AddDays(-10).Month + "月" + date.AddDays(-10).Day + "日");
            #endregion

            #region 演習2
            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int birthYear = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int birthMonth = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int birthDay = int.Parse(Console.ReadLine());

            DateTime birth = new DateTime(birthYear,birthMonth,birthDay);
            TimeSpan interval = DateTime.Today - birth;

            Console.WriteLine("あなたは生まれてから今日まで"+interval.Days+"日目です。");
            #endregion

            #region 誕生日の曜日
            switch ((int)birth.DayOfWeek)
            {
                case 0:
                    Console.WriteLine("日曜日");
                    break;
                case 1:
                    Console.WriteLine("月曜日");
                    break;
                case 2:
                    Console.WriteLine("火曜日");
                    break;
                case 3:
                    Console.WriteLine("水曜日");
                    break;
                case 4:
                    Console.WriteLine("木曜日");
                    break;
                case 5:
                    Console.WriteLine("金曜日");
                    break;
                case 6:
                    Console.WriteLine("土曜日");
                    break;
                default:
                    break;
            }
            #endregion
        }
    }
}
