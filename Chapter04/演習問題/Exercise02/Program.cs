using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise01;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var ym = new YearMonth(2023, 12);
            var c21 = ym.Is21Century;
            Console.WriteLine(c21);
            var ym2 = ym.AddOneMonth();
            Console.WriteLine(ym2.Month);
        }
    }
}
