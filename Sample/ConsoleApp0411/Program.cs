using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {

            Console.Write("数字を入力：");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine();
            //①
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //②
            for (int i = 0; i < count; i++)
            {
                for (int j = count - 1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //③
            for (int i = 0; i < count; i++)
            {
                for (int j = count - 1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i + 1; k++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //④
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = count; k > i; k--)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //⑤
            int amount, pay, change;
            string[] moneyName = { "一万円札", "五千円札", "二千円札",
                                    "千円札\t", "五百円玉", "百円玉\t",
                                     "五十円玉", "十円玉\t", "五円玉\t", "一円玉\t", };
            int[] money = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1, };


            Console.Write("金額：");
            amount = int.Parse(Console.ReadLine());
            Console.Write("支払：");
            pay = int.Parse(Console.ReadLine());
            change = pay - amount;
            Console.Write("釣銭：" + change + "円\n");

            
            moneyOutput(moneyName, money, change);
        }
        public static void moneyOutput(string[] moneyName, int[] money, int change) {
            for (int i = 0; i < moneyName.Length; i++)
            {
                Console.Write(moneyName[i] + "：");
                astaOut(change / money[i]);
                change %= money[i];
            }
        }
        public static void astaOut(int num) {
            for (int i = 0; i < num; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

    }
}
