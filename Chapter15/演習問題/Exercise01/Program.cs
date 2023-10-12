using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var maxPrice = Library.Books.Max(x => x.Price);
            var books = Library.Books.Where(b => b.Price == maxPrice);
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_3() {
            var publishYears = Library.Books.GroupBy(b => b.PublishedYear);
            foreach (var books in publishYears) {
                Console.Write(books.Key + "年：");
                Console.WriteLine(books.Count()+"冊");
            }
        }

        private static void Exercise1_4() {
            var groups = Library.Books.GroupBy(b => b.PublishedYear);
            foreach (var books in groups) {
                foreach (var book in books.OrderByDescending(b => b.Price)) {
                    var cat = Library.Categories.First(b => b.Id == book.CategoryId);
                    Console.WriteLine("{0}年 {1}円 {2} ({3})",books.Key,book.Price,book.Title,cat.Name);
                }
            }
        }

        private static void Exercise1_5() {
            
        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {
            
        }
    }
}
