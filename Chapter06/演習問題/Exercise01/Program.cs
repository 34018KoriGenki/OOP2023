using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise1_2(int[] numbers) {
            Console.WriteLine("{0}\n{1}", numbers.ElementAt(numbers.Length - 2), numbers.Last());
        }

        private static void Exercise1_3(int[] numbers) {
            var convertStr = numbers.Select(x=> x.ToString());
            foreach (var str in convertStr) {
                Console.WriteLine(str);
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var sortNumbers = numbers.OrderBy(x => x);
            Console.WriteLine("{0}\n{1}\n{2}",sortNumbers.ElementAt(0),sortNumbers.ElementAt(1),sortNumbers.ElementAt(2));
        }

        private static void Exercise1_5(int[] numbers) {
        }
    }
}
