using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            Console.Write("数字：");
            var str = Console.ReadLine();
            if (int.TryParse(str,out var result)) {
                Console.WriteLine ($"{result:#,0}") ;
            } else {
                Console.WriteLine("数字ではありません");
            }
        }
    }
}
