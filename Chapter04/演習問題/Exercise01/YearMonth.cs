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

        public YearMonth(int year,int month) {
            Year = year;
            Month = month;
        }

        public YearMonth AddOneMonth() {
            return new YearMonth(Year, Month < 12 ? Month+1 : 1);
        }

        override
        public string ToString() {
            return Year+"年"+Month+"月";
        }
    }
}
