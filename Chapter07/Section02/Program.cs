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
            var prefInfo = new Dictionary<string, List<CityInfo>>();
            prefInfo = InputPref(prefInfo);
            OutputPref(prefInfo);
        }

        static Dictionary<string, List<CityInfo>> InputPref(Dictionary<string, List<CityInfo>> prefInfo) {
            string pref, city, str;
            int population;
            do {
                Console.Write("県名：");
                pref = emCon(Console.ReadLine());
            } while (pref == "");
            while (pref != "999") {
                do {
                    Console.Write("市町村名：");
                    city = Console.ReadLine();
                } while (city == "");
                do {
                    Console.Write("人口数：");
                    str = emCon(Console.ReadLine());
                    if (int.TryParse(str, out population)) {
                        population = int.Parse(str);
                    } else {
                        str = "";
                    }
                } while (str == "");


                if (!prefInfo.ContainsKey(pref)) {
                    prefInfo[pref] = new List<CityInfo>();
                }
                var cityInfo = new CityInfo() { City = city, Population = population };
                prefInfo[pref].Add(cityInfo);

                do {
                    Console.Write("県名：");
                    pref = emCon(Console.ReadLine());
                } while (pref == "");
            }

            return prefInfo;
        }

        private static void OutputPref(Dictionary<string, List<CityInfo>> prefInfo) {
            string str;
            int num = 0;
            do {
                Console.WriteLine("1.一覧表示 2.県名指定");
                str = emCon(Console.ReadLine());
                if (int.TryParse(str, out num)) {
                    num = int.Parse(str);
                } else {
                    str = "";
                }
            } while (str == "");

            if (num == 1) {
                foreach (var item in prefInfo.Keys) {
                    Console.Write("{0}", item);
                    PrintInfo(prefInfo, item);
                }
            } else {
                Console.Write("県名：");
                str = Console.ReadLine();
                if (prefInfo.ContainsKey(str)) {
                    PrintInfo(prefInfo, str);
                } else {
                    Console.WriteLine("存在しません");
                }
            }
        }

        private static void PrintInfo(Dictionary<string, List<CityInfo>> prefInfo, string item) {
            foreach (var info in prefInfo[item]) {
                Console.Write("【{0}({1})】", info.City, info.Population);
            }
            Console.WriteLine();
        }

        private static string emCon(string str) {
            var cultureInfo = new CultureInfo("ja-JP");
            return Strings.StrConv(str, VbStrConv.Narrow);
        }

    }
    class CityInfo {
        public string City { get; set; }
        public int Population { get; set; }
    }
}