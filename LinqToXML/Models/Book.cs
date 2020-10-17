using System;
using System.Xml.Linq;
using LinqToXML.Extentions;

namespace LinqToXML.Models
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }

        public Book()
        {
        }

        public Book(string author, string title, string genre, float price, DateTime publishDate, string description)
        {
            Author = author;
            Title = title;
            Genre = genre;
            Price = price;
            PublishDate = publishDate;
            Description = description;
        }

        public static Book FromXElement(XElement xElement)
        {
            Book book = new Book
            {
                Author = xElement.ElementValue("author"),
                Title = xElement.ElementValue("title"),
                Genre = xElement.ElementValue("genre"),
                Price = float.Parse(xElement.ElementValue("price")),
                PublishDate = DateTime.Parse(xElement.ElementValue("publish_date")),
                Description = xElement.ElementValue("description")
            };

            return book;
        }
    }
}