using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter { 
    //ポンド単位を表すクラス
    public class PoundUnit : DistanceUnit {
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit{ Name = "dr" , Coefficient = 1, },
            new PoundUnit{ Name = "oz" , Coefficient = 16, },
            new PoundUnit{ Name = "lb" , Coefficient = 16 * 16, },
            new PoundUnit{ Name = "st" , Coefficient = 16 * 16 * 14, },
        };

        public static ICollection<PoundUnit> Units => units;

        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 1.7718452 / this.Coefficient;
        }
    }
}
