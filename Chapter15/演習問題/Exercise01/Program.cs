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
                Console.WriteLine(books.Count() + "冊");
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books
                                .OrderByDescending(b => b.PublishedYear)
                                .ThenBy(b => b.CategoryId)
                                .Join(Library.Categories,
                                        book => book.CategoryId,
                                        category => category.Id,
                                        (book, category) => new {
                                            PublishedYear = book.PublishedYear,
                                            price = book.Price,
                                            Title = book.Title,
                                            Category = category.Name,
                                        });
            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年 {book.price}円 {book.Title} ({book.Category})");
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