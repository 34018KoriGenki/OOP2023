using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

        }

        private static object NextDay(DateTime dateTime, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(dateTime.DayOfWeek);
            if (days <= 0) {
                days += 7;
            }
            return dateTime.AddDays(days);
        }
    }
}
