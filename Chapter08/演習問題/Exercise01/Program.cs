﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //2019/1/15 19:48
            var str = dateTime.ToString("yyyy/MM/dd HH:mm");
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2019年01月15日 19時48分32秒
            var str = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            Console.WriteLine(str);

        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            //平成31年 1月15日(火曜日)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = dateTime.ToString(@"ggyy年 MM月dd日", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            Console.WriteLine("{0} ({1})",str,dayOfWeek);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dateStr = dateTime.ToString("ggyy年MM月dd日(dddd)", culture);
            //ゼロサプレスを実施(不要なゼロを取り除く)
            var str = Regex.Replace(dateStr,@"0(\d)","$1");
            Console.WriteLine(str);
        }

        
    }
}
