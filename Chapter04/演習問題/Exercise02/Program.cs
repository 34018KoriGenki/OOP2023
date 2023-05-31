using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise01;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1990, 5),
                new YearMonth(1990, 1),
                new YearMonth(2000, 7),
                new YearMonth(202, 9),
                new YearMonth(202, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");


            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }

        private static YearMonth Exercise2_3(YearMonth[] ymCollection) {
            return FindFirst21C(ymCollection);
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            Console.WriteLine(Exercise2_3(ymCollection)?.ToString() ?? DefaultMessage());
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var yms = ymCollection.Select(ym => ym.AddOneMonth());
            Exercise2_2(yms.OrderBy(ym => ym.Year).ThenBy(ym => ym.Month).ToArray());
        }

        public static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                if (ym.Is21Century) {
                    return ym;
                }
            }
            return null;
        }

        public static string DefaultMessage() {
            return "21世紀のデータはありませんでした。";
        }
    }
}
