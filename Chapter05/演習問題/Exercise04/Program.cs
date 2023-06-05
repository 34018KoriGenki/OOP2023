using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var baseStr = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var infoStr = new[] { "作家  ：", "代表作：", "誕生年：" };
            var words = baseStr.Split(';');
            for (int i = 0;i < words.Length;i++) {
                Console.WriteLine(infoStr[i % 3] + words[i].Remove(0, words[i].IndexOf('=') + 1));
            }
        }
    }
}
