using System;
using System.Linq;
using System.Xml.Linq;
using LinqToXML.Models;

namespace LinqToXML
{
    // Avem un fisier xml cu o lista de carti
    // de afisat numele autorilor impreuna cu informatia despre cartile lor (titlu, data publicarii, pret)
    // autorii trebuie afisati in ordine descrescatoare dupa numarul cartilor afisate si in ordine crescatoare dupa nume
    // cartile unui autor trebuie sa fie afisate in ordine crescatoare dupa data publicarii
    // de afisat doar cartile cu pretul mai mare de $5.0
    internal static class Program
    {
        private static void Main(string[] args)
        {
            XDocument document = XDocument.Load("books.xml");

            var books = document.Descendants("book").Select(Book.FromXElement).ToList();

            var orderedBooks = books.Where(b => b.Price > 5)
                .OrderBy(b => b.PublishDate).GroupBy(book => book.Author)
                .OrderByDescending(grouping => grouping.Count())
                .ThenBy(grouping => grouping.Key).ToList();

            foreach (var bookGrouping in orderedBooks)
            {
                Console.WriteLine($"Author: {bookGrouping.Key}. Total books: {bookGrouping.Count()}");
                Console.WriteLine("This author's books: ");
                foreach (var book in bookGrouping)
                {
                    Console.WriteLine($"{book.Title}. Publish date: {book.PublishDate}. Price: {book.Price}");
                }

                Console.WriteLine();
            }
        }
    }
}