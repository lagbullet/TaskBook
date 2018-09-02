using System;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"E:\Test\TestJson.txt");
            Book book = Book.FromJSON(text);
            book.Show();
            Console.ReadLine();
            text = System.IO.File.ReadAllText(@"E:\Test\TestXml.txt");
            Book book1 = Book.FromXML(text);
            book1.Show();
            Console.ReadLine();
            Console.WriteLine(book.ToJSON());
            Console.ReadLine();
            Console.WriteLine(book1.ToXML());
            Console.ReadLine();
        }
    }
}
