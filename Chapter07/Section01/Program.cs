using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            
            var prefInfo = new Dictionary<string, string>();

            prefInfo = InputPrefInfo(prefInfo);

            OutputPrefInfo(prefInfo);
        }

        private static Dictionary<string, string> InputPrefInfo(Dictionary<string, string> prefInfo) {
            var judge = "Y";
            string pref,city;
            Console.WriteLine("***県庁所在地の登録***");
            Console.Write("県名：");
            pref = Console.ReadLine();

            while (!(judgement(pref, "999"))) {
                if (prefInfo.Any(n => n.Key == pref) && pref != "") {
                    Console.WriteLine("県名重複、上書きしますか?");
                    bool v = (judgement(judge, "Y") || judgement(judge, "N"));
                    do {
                        Console.Write("(Y/N)：");
                        judge = Console.ReadLine();
                    } while (!v);
                }

                if (pref != "" && judgement(judge, "Y")) {
                    do {
                        Console.Write("所在地：");
                        city = Console.ReadLine();
                    } while (city == "");
                    prefInfo[pref] = city;

                }
                Console.Write("県名：");
                pref = Console.ReadLine();
            }

            return prefInfo;
        }

        private static void OutputPrefInfo(Dictionary<string, string> prefInfo) {
            Console.WriteLine("***県庁所在地の出力***");
            Console.Write("県名を入力：");
            try {
                Console.WriteLine($"{prefInfo[Console.ReadLine()]}です。");
            } catch (Exception) {
                Console.WriteLine("データが存在しません。");
            }
        }

        private static bool judgement(string judge, string str) {
            var cultureInfo = new CultureInfo("ja-JP");
            return string.Compare(judge, str, cultureInfo, CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase) == 0;
        }
    }
}
