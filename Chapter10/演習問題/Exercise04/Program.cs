using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");
            var patt = @"\b(V|v)ersion\s*=\s*""v4.0""";
            
            var newLines = lines.Select(s => Regex.Replace(s,patt,@"version=""v5.0"""));

            // 書き込み
            File.WriteAllLines("sample.txt",newLines);
            
            // これ以降は確認用
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
