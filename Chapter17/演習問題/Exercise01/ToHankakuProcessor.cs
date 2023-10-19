using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class ToHankakuProcessor : TextProcessor {

        private static Dictionary<char, char> _dictionary = new Dictionary<char, char> {
            { '０','0'},{ '１','1'},{ '２','2'},{ '３','3'},{ '４','4'},
            { '５','5'},{ '６','6'},{ '７','7'},{ '８','8'},{ '９','9'},
        };

        private List<string> _newLine = new List<string>();

        protected override void Execute(string line) {
            foreach (var c in _dictionary) {
                line = line.Replace(c.Key, c.Value);
            }
            _newLine.Add(line);
        }
        protected override void Terminate() {
            _newLine.ForEach(s => Console.WriteLine(s));
        }
    }
}
