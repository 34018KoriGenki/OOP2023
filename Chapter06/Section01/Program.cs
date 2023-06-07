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
            var booksObj = books.Where(x => x.Title.Contains("物語")).OrderBy(x=> x.Title.Count());
            Console.WriteLine("タイトルに「物語」が含まれている本の平均ページ数：{0}枚", booksObj.Average(x=> x.Pages));
            Console.WriteLine("***タイトル表示***");
            foreach (var book in booksObj) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
