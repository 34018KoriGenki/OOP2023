using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("県庁所在地の登録");
            var pref = new Dictionary<string, string>();
            var str = "";
            do {
                Console.Write("県名：");
                str = Console.ReadLine();
                if (str == "999") break;
                Console.Write("所在地：");
                pref[str] = Console.ReadLine();
            } while (true);

            Console.Write("県名を入力：");
            try {
                Console.WriteLine($"{pref[Console.ReadLine()]}です。");
            } catch (Exception) {
                Console.WriteLine("データが存在しません。");
            }
        }
    }
}
