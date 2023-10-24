using Exercise03.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise03 {
    class ToHankakuProcessor : ITextFileService {

        private static Dictionary<char, char> _dictionary = new Dictionary<char, char> {
            { '０','0'},{ '１','1'},{ '２','2'},{ '３','3'},{ '４','4'},
            { '５','5'},{ '６','6'},{ '７','7'},{ '８','8'},{ '９','9'},
        };

        private List<string> _newLine = new List<string>();

        public void Initialize(string fname) { }

        void ITextFileService.Execute(string line) {
            var newLine = Regex.Replace(line, "[０-９]", c => _dictionary[c.Value[0]].ToString());
            _newLine.Add(newLine);
        }
        void ITextFileService.Terminate() {
            _newLine.ForEach(s => Console.WriteLine(s));
        }

    }
}
