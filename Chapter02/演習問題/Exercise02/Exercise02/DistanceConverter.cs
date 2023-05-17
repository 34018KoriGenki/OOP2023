using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    public static class InchConverter {

        //定数(JavaだとFinalキーワード、privateだから小文字でもおk)
        //constはprivate推奨
        #region publicの定数にしたい場合
        //public static readonly double ratio = 0.3048; 
        #endregion
        private const double ratio = 0.0254;

        public static double ToMeter(double Inch) {
            return Inch * ratio;
        }
        public static double FromMeter(double Inch) {
            return Inch / ratio;
        }
    }
}
