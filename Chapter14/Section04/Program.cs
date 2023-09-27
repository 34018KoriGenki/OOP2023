using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            var results = GetNewsTopicsFromYahoo("it");
            foreach (var s in results)
                Console.WriteLine(s);
            Console.ReadLine();
        }

        private static void OpenReadSample() {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(@"http://gihyo.jp/book/list"))
            using (var sr = new StreamReader(stream,Encoding.UTF8)) {
                string html = sr.ReadToEnd();
                Console.WriteLine(html);
            }
        }

        private static IEnumerable<string> GetNewsTopicsFromYahoo(string topic) {
            using (var wc = new WebClient()) {
                wc.Headers.Add("Content-type", "charset=UTF-8");
                var uriString = string.Format(
                    @"https://news.yahoo.co.jp/rss/topics/{0}.xml", topic);
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);

                XDocument xdoc = XDocument.Load(stream);
                var nodes = xdoc.Root.Descendants("title");
                foreach (var node in nodes) {
                    string s = Regex.Replace(node.Value, "【|】", "");
                    yield return node.Value;
                }
            }
        }
    }
}
