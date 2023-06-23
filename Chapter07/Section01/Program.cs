using Microsoft.VisualBasic;
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
            string pref, city;
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
                    prefInfo[pref] = city;

                }
                judge = "Y";
                Console.Write("県名：");
                pref = Console.ReadLine();
            }

            return prefInfo;
        }

        private static void OutputPrefInfo(Dictionary<string, string> prefInfo) {
            string writePref;
            string str;
            int num;
            Console.WriteLine("***県庁所在地の出力***");
            Console.Write("1.一覧表示  2.県名指定\n>");
            str = Console.ReadLine();

            num = Comvert(Form(str));

            while (num<0||num>3) {
                Console.Write("1.一覧表示  2.県名指定\n>");
                str = Console.ReadLine();
                num = Comvert(Form(str));
            }
            if (num == 1) {
                foreach (var item in prefInfo) {
                    Console.WriteLine("県名：{0}\n所在地：{1}", item.Key, item.Value);
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

        private static int Comvert(string str) {
            for (int i = 0;i <= 9;i++) {
            if (str == i.ToString()) return i;
            }
            var cultureInfo = new CultureInfo("ja-JP");
            for (int i = 0;i <= 9;i++) {
                if (string.Compare(i.ToString(), str, cultureInfo, CompareOptions.IgnoreWidth) == 0) return i;
            }
            return Comvert(Form(str));
        }
    }
}
