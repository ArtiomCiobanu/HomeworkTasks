using System;
using System.Xml.Linq;

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
                Author = xElement.Element("author").Value,
                Title = xElement.Element("title").Value,
                Genre = xElement.Element("genre").Value,
                Price = float.Parse(xElement.Element("price").Value),
                PublishDate = DateTime.Parse(xElement.Element("publish_date").Value),
                Description = xElement.Element("description").Value
            };

            return book;
        }
    }
}