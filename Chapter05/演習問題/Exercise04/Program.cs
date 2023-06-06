using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start(); //タイマースタート
#if NonArray
            var baseStr = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            ReceptionInfo(baseStr);
#elif StringArray
            string[] baseLines = { "Novelist=谷崎潤一郎a;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎b;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎c;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎d;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎f;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎g;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎b;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎c;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎d;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎f;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎g;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
                                "Novelist=谷崎潤一郎e;BestWork=春琴抄;Born=1886",
            };
            ReceptionInfo(baseLines);
#endif
            Console.WriteLine("実行時間：{0}s", sw.Elapsed.ToString(@"ss\.fffffff")); //時間表示
        }

        private static void ReceptionInfo(string[] baseLines) {
            foreach (var baseStr in baseLines) {
                ReceptionInfo(baseStr);
            }
        }

        private static void ReceptionInfo(string baseStr) {
            var words = baseStr.Split(';');
            Print(words);
        }

        private static void Print(string[] words) {
            string[] infoStr = { "作家  ：", "代表作：", "誕生年：" };
            for (int i = 0;i < words.Length;i++) {
                Console.WriteLine(infoStr[i] + words[i].Substring(words[i].IndexOf('=') + 1));
            }
        }
    }
}