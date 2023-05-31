using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Console.Write("1つ目の文字列：");
            var str1 = Console.ReadLine();
            Console.Write("2つ目の文字列：");
            var str2 = Console.ReadLine();

            if (string.Compare(str1, str2, ignoreCase: true) == 0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
