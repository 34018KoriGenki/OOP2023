using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-13 (ConverterBaseの具象クラス)

    public class MeterConverter : ConverterBase {
        protected override double Ratio { get => 1; }
        public override string UnitName { get => "メートル"; }

        public override bool IsMyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;
    }

    public class FeetConverter : ConverterBase {
        protected override double Ratio { get => 0.3048; }
        public override string UnitName { get => "フィート"; }

        public override bool IsMyUnit(string name) =>
            name.ToLower() == "feet" || name == UnitName;
    }

    public class InchConverter : ConverterBase {
        protected override double Ratio { get => 0.0254; }
        public override string UnitName { get => "インチ"; }

        public override bool IsMyUnit(string name) =>
            name.ToLower() == "inch" || name == UnitName;
    }

    public class YardConverter : ConverterBase {
        protected override double Ratio { get => 0.9144; }
        public override string UnitName { get =>"ヤード"; }

        public override bool IsMyUnit(string name) =>
            name.ToLower() == "yard" || name == UnitName;
    }
}
