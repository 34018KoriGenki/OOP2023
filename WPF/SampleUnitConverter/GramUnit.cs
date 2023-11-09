using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //グラム単位を表すクラス
    public class GramUnit : DistanceUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit{ Name = "g" , Coefficient = 1, },
            new GramUnit{ Name = "kg" , Coefficient = 1000 , },
            new GramUnit{ Name = "t" , Coefficient = 1000 * 1000 , },
        };

        public static ICollection<GramUnit> Units => units;

        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 1.7718452 / this.Coefficient;
        }
    }
}
