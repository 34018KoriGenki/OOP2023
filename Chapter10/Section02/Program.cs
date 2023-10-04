﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            //IsMatch01();
            //IsMatch02();
            //StartWith();
            //EndWith();
            //PerfectMatch();
            PerfectMatch02();
        }

        //静的メソッドを使用した場合
        private static void IsMatch01() {
            var text = "private List<string> result = new List<string>();";
            bool isMatch = Regex.IsMatch(text, @"List<\w+>");
            Console.WriteLine(isMatch ? "見つかりました" : "見つかりませんでした");
        }

        //インスタンスメソッドを使用した場合
        private static void IsMatch02() {
            var text = "private List<string> result = new List<string>();";
            var regex = new Regex(@"List<\w+>");
            bool isMatch = regex.IsMatch(text);
            Console.WriteLine(isMatch ? "見つかりました" : "見つかりませんでした");
        }

        private static void StartWith() {
            var text = "using System.Text.RegularExpressions;";
            bool isMatch = Regex.IsMatch(text, @"^using");
            Console.WriteLine(isMatch ? "'using'で始まっています" : "'using'で始まっていません");
        }

        private static void EndWith() {
            var text = "Regexクラスを使った文字列操作について説明します。";
            bool isMatch = Regex.IsMatch(text, @"ます。$");
            Console.WriteLine(isMatch ? "'ます。'で終わっています" : "'ます。'で終わっていません");
        }

        //10-5
        public static void PerfectMatch() {
            var strings = new[] { "Microsoft Windows", "Windows Server", "Windows", };
            var regex = new Regex(@"^(W|w)indows$");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("{0}行と一致", count);
        }

        //10-7
        public static void PerfectMatch02() {
            var strings = new[] { "13000", "-50.6", "0.123",  "+180.00",
        "10.2.5", "320-0851", " 123", "$1200", "500円","320-851", };
            var regex = new Regex(@"^\d{3}-\d{4}$");
            foreach (var s in strings) {
                var isMatch = regex.IsMatch(s);
                if (isMatch)
                    Console.WriteLine(s);
            }
        }
    }
}