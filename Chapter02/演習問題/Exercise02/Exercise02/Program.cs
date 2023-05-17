using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            PrintFeetToMeterList(1, 10);
        }

        //フィートからメートルへの対応表を出力
        static void PrintFeetToMeterList(int start, int stop) {
            for (int inch = start;inch <= stop;inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine("{0} inch = {1:0.0000} m", inch, meter);
            }
        }
    }
}
