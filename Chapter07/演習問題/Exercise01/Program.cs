﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Console.WriteLine();
            Exercise1_2(text);
        }

        private static void Exercise1_1(string text) {
            var dict = new Dictionary<char, int>();
            var txt = text.ToUpper();
            for (int i = 0;i < 26;i++) {
                var key = (char)('A' + i);
                dict.Add(key,txt.Count(c => c == key));
            }
            foreach (var item in dict) {
                Console.WriteLine("\'{0}\'：{1}",item.Key,item.Value);
            }
            
        }

        private static void Exercise1_2(string text) {
            
        }
    }
}
