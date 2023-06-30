using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var abbrs = new Abbreviations();
            Console.WriteLine(abbrs.Count);
            //Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");
            Console.WriteLine(abbrs.Count);

            Console.WriteLine(abbrs.Remove("IOC") ? "成功" : "失敗");

            Console.WriteLine(abbrs.Count);

            Console.WriteLine(abbrs.Remove("FIFA") ? "成功" : "失敗");

            Console.WriteLine(abbrs.Count);

            foreach (var abbr in abbrs.Where(k => k.Key.Length == 3)) {
                Console.WriteLine("{0}={1}", abbr.Key, abbr.Value);
            }
        }
    }
}
