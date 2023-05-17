using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            if (args.Length >= 3 && args[0] == "-tom") {
                PrintInchToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            } else if (args.Length >= 3 && args[0] == "-toi") {
                PrintMeterToInchList(int.Parse(args[1]), int.Parse(args[2]));
            }
        }

        //フィートからメートルへの対応表を出力
        static void PrintInchToMeterList(int start, int stop) {
            for (int inch = start;inch <= stop;inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine("{0} inch = {1:0.0000} m", inch, meter);
            }
        }

        static void PrintMeterToInchList(int start, int stop) {
            for (int inch = start;inch <= stop;inch++) {
                double meter = InchConverter.FromMeter(inch);
                Console.WriteLine("{0} m = {1:0.0000} inch", inch, meter);
            }
        }
    }
}
