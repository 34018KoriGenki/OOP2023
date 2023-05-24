using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1(names);
            Console.WriteLine("----------");
            Exercise2_2(names);
            Console.WriteLine("----------");
            Exercise2_3(names);
            Console.WriteLine("----------");
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                Console.WriteLine(names.FindIndex(s => s == line));
            }while(true);
        }

        private static void Exercise2_2(List<string> names) {
            Console.WriteLine(names.Count(s => s.Contains('o')));

            //別パターン
            //Console.WriteLine(names.Where(s => s.Contains('o')).Count());
        }

        private static void Exercise2_3(List<string> names) {
            var city = names.Where(s => s.Contains('o')).ToArray();
            foreach (var item in city) {
                Console.WriteLine(item);
            }
            
        }

        private static void Exercise2_4(List<string> names) {
            foreach (var item in names.Where(s => s.StartsWith("B")).Select(s=>s.Count()/* ←s.lengthでも可 */)) {
                Console.WriteLine(item);
            }

            //都市名出すとき
            var temp = names.Where(s => s.StartsWith("B")).ToList();
            temp.ForEach(s => Console.WriteLine("{0},{1}",s,s.Count()));

            //正解
            var selected = names.Where(s => s.StartsWith("B")).Select(s => new { s, s.Length });
            foreach (var item in selected) {
                Console.WriteLine("{0},{1}",item.s,item.Length);
            }
        }
    }
}
