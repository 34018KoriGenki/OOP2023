using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class ConverterFactory {
        private static ConverterBase[] _conveters = new ConverterBase[] {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
        };

        public static ConverterBase GetInstance(string name) =>
            _conveters.FirstOrDefault(x => x.IsMyUnit(name));
    }
}
