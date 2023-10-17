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
            var query = Library.Books.GroupBy(b => b.PublishedYear)
                .Select(g => new { PublishYears = g.Key, Count = g.Count() })
                .OrderBy(x => x.PublishYears);
            foreach (var item in query) {
                Console.WriteLine("{0}年 {1}冊", item.PublishYears, item.Count);
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books
                                .OrderByDescending(b => b.PublishedYear)
                                .ThenByDescending(b => b.Price)
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
            var books = Library.Books
                                .Where(b => b.PublishedYear == 2016)
                                .Join(Library.Categories,
                                        book => book.CategoryId,
                                        category => category.Id,
                                        (book, category) => category.Name
                                        )
                                .Distinct();
            foreach (var item in books) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise1_6() {
            var books = Library.Books.Join(Library.Categories,
                                book => book.CategoryId,
                                category => category.Id,
                                (book, category) => new { Category = category.Name,
                                                            Title = book.Title})
                                .OrderBy(b => b.Category)
                                .GroupBy(b => b.Category);
            foreach (var g in books) {
                Console.WriteLine($"#{g.Key}");
                foreach (var book in g) {
                    Console.WriteLine($"\t{book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var books = Library.Books.OrderBy(b => b.PublishedYear)
                                        .Join(Library.Categories,
                                            book => book.CategoryId,
                                            category => category.Id,
                                            (book, category) => new {
                                                Category = category.Name,
                                                Title = book.Title,
                                                PublishYear = book.PublishedYear,
                                            })
                                        .Where(b => b.Category == "Development")
                                        .GroupBy(b => b.PublishYear);
            foreach (var items in books) {
                Console.WriteLine($"#{items.Key}年");
                foreach (var item in items) {
                    Console.WriteLine($"\t{item.Title}");
                }
            }

            //解答
            var catid = Library.Categories.Single(c => c.Name == "Development").Id;
            var groups = Library.Books.Where(b => b.CategoryId == catid)
                                        .GroupBy(b => b.PublishedYear)
                                        .OrderBy(b => b.Key);
            foreach (var group in groups) {
                Console.WriteLine($"#{group.Key}年");
                foreach (var book in group) {
                    Console.WriteLine($"{book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var groups = Library.Categories.GroupJoin(Library.Books,
                                                    c => c.Id,
                                                    b => b.CategoryId,
                                                    (c,books) => new {
                                                        Category = c.Name,
                                                        Count = books.Count()}
                                                        ).Where(b => b.Count >= 4);
            foreach (var obj in groups) {
                Console.WriteLine($"{obj.Category}");
            }
        }
    }
}