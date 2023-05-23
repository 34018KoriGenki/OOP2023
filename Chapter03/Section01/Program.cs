﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {

        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4, };

            //5の倍数
            //int count = numbers.Count(n => n % 5 == 0);        //拡張メソッド,ラムダ演算式(ラムダ式)

            //合計値
            var sum = numbers.Where(n => n % 2 == 0).Average();
            Console.WriteLine(sum);
        }
    }
}
