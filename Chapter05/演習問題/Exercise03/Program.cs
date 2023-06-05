using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            //{\rtf1}
        }

        private static void Exercise3_1(string text) {
            var count = text.Count(s=>s==' ');
            Console.WriteLine("空白の数：{0}",count);
        }

        private static void Exercise3_2(string text) {
            var str = text.Replace("big","small");
            Console.WriteLine(str);
        }

        private static void Exercise3_3(string text) {
            var str = text.Split(' ');
            Console.WriteLine("単語数：{0}",str.Length);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ');
            foreach (var word in words) {
                Console.Write(word.Length <= 4 ? word+"\n":null);
            }
        }

        private static void Exercise3_5(string text) {
            
        }
    }
}
