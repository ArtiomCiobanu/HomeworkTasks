using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXML
{
    // Avem un fisier xml cu o lista de carti
    // de afisat numele autorilor impreuna cu informatia despre cartile lor (titlu, data publicarii, pret)
    // autorii trebuie afisati in ordine descrescatoare dupa numarul cartilor afisate si in ordine crescatoare dupa nume
    // cartile unui autor trebuie sa fie afisate in ordine crescatoare dupa data publicarii
    // de afisat doar cartile cu pretul mai mare de $5.0
    internal static class ProgramOld
    {
        private static void MainOld(string[] args)
        {
            XDocument document = XDocument.Load("books.xml");

            var query =
                (from book in document.Descendants("book")
                    select new
                    {
                        Title = book.Element("title").Value,
                        Price = book.Element("price"),
                        Author = book.Element("author").Value
                    });

            foreach (var item in query)
            {
                Console.WriteLine(item.Author);

                Console.WriteLine(
                    $"\t{(string)item.Title,-40}" +
                    $"${(decimal)item.Price:0#.00}");

                //Console.WriteLine($"\t{"Title",-40}{"Publish date",-15}{"Price",-3}");

                Console.WriteLine();
            }
        }
    }
}
