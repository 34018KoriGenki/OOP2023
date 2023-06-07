using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9,7,5,4,2,4,0,-4,-1,0,4,};
            Console.WriteLine(numbers.Average());

            var books = Books.GetBooks();
            var booksObj = books.Where(x => x.Title.Contains("物語")).OrderByDescending(x => x.Price);
            foreach (var book in booksObj) {
                Console.WriteLine("{0}：{1}円",book.Title,book.Price);
            }

        }
    }
}
