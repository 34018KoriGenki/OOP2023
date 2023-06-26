using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            var prefInfo = new Dictionary<string, CityInfo>();

            prefInfo = InputPrefInfo(prefInfo);

            OutputPrefInfo(prefInfo);
        }

        private static Dictionary<string, CityInfo> InputPrefInfo(Dictionary<string, CityInfo> prefInfo) {
            var judge = "Y";
            string pref, city, str;
            int population = 0;
            Console.WriteLine("***県庁所在地の登録***");
            Console.Write("県名：");
            pref = Console.ReadLine();

            while (!Judgement(pref, "999")) {
                if (prefInfo.Any(n => n.Key == pref) && pref != "") {
                    Console.WriteLine("県名重複、上書きしますか?");
                    do {
                        Console.Write("(Y/N)：");
                        judge = Console.ReadLine();
                    } while (!(Judgement(judge, "Y") || Judgement(judge, "N")));
                }

                if (pref != "" && Judgement(judge, "Y")) {
                    do {
                        Console.Write("所在地：");
                        city = Console.ReadLine();
                    } while (city == "");
                    prefInfo[pref] = new CityInfo();
                    prefInfo[pref].City = city;
                    do {
                        Console.Write("人口：");
                        str = emCon(Console.ReadLine());
                        if (int.TryParse(str, out population)) {
                            population = int.Parse(str);
                        } else {
                            str = "";
                        }
                    } while (str == "");
                    prefInfo[pref].Population = population;

                }
                judge = "Y";
                Console.Write("県名：");
                pref = Console.ReadLine();
            }

            return prefInfo;
        }

        private static void OutputPrefInfo(Dictionary<string, CityInfo> prefInfo) {
            string writePref;
            string str;
            int num;
            Console.WriteLine("***県庁所在地の出力***");
            Console.Write("1.一覧表示  2.県名指定\n>");
            str = Console.ReadLine();

            num = Convert.ToInt32(emCon(Form(str)));

            while (num < 0 || num > 3) {
                Console.Write("1.一覧表示  2.県名指定\n>");
                str = Console.ReadLine();
                num = Convert.ToInt32(Form(str));
            }
            if (num == 1) {
                foreach (var item in prefInfo) {
                    Console.WriteLine("{0}【{1}({2})】", item.Key, item.Value.City, item.Value.Population);
                }

            } else {
                Console.Write("県名を入力：");
                writePref = Console.ReadLine();
                try {
                    while (Judgement(writePref, "")) {
                        Console.Write("県名を入力：");
                        writePref = Console.ReadLine();
                    }
                    Console.WriteLine($"{prefInfo[writePref]}です。");
                } catch (Exception) {
                    Console.WriteLine("データが存在しません。");
                }

            }
        }

        private static string Form(string str) {
            while (Judgement(str, "")) {
                Console.Write("1.一覧表示  2.県名指定\n>");
                str = Console.ReadLine();
            }

            return str;
        }

        private static bool Judgement(string judge, string str) {
            var cultureInfo = new CultureInfo("ja-JP");
            return string.Compare(judge, str, cultureInfo, CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase) == 0;
        }
        private static string emCon(string str) {
            var cultureInfo = new CultureInfo("ja-JP");
            return Strings.StrConv(str, VbStrConv.Narrow);
        }

        class CityInfo {
            public string City { get; set; }
            public int Population { get; set; }
        }
    }
}
