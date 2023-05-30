using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth(Year + 1, 1);
            } else {
                return new YearMonth(Year, Month + 1);
            }

            //int addYear = Month < 12 ? Year : Year + 1;
            //int addMonth = Month < 12 ? Month + 1 : 1;
            //return new YearMonth(addYear,addMonth);
        }

        override
        public string ToString() {
            return Year + "年" + Month + "月";
        }
    }
}
