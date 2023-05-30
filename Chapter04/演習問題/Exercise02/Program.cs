using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise01;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var yms = new YearMonth[] {
                new YearMonth(2000,1),
                new YearMonth(2010,5),
                new YearMonth(2019,12),
                new YearMonth(2099,12),
                new YearMonth(2100,1),
            };
            foreach (var ym in yms) {
                Console.WriteLine(ym);
            }
        }
    }
}
