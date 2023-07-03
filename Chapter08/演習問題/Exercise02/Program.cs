using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            var toDay = dateTime.ToString("yy/MM/dd");
            string nextDay;
            for (int i = 0;i < 7;i++) {
                nextDay = NextDay(dateTime, (DayOfWeek)i).ToString("yy/MM/dd(ddd)");
                Console.WriteLine("{0}の次週の{1}は{2}",toDay,(DayOfWeek)i,nextDay);
            }
            
        }

        public static DateTime NextDay(DateTime date , DayOfWeek dayOfWeek) {

            var days = (int)dayOfWeek - (int)date.DayOfWeek;
            
            days += 7;
            
            return date.AddDays(days);
        }
    }
}
