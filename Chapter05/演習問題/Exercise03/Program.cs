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
            var spaces = text.Count(c => c == ' ');
            Console.WriteLine("空白の数：{0}", spaces);
        }

        private static void Exercise3_2(string text) {
            var repaced = text.Replace("big", "small");
            Console.WriteLine(repaced);
        }

        private static void Exercise3_3(string text) {
            var str = text.Split(' ').Length;
            Console.WriteLine("単語数：{0}", str);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(word => word.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();
            if (array.Length > 0) {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array.Skip(1)) {
                    sb.Append(" ").Append(word);
                }
                var createWords = sb.ToString();
                Console.WriteLine(createWords);
            }

        }
    }
}
