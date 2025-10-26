using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _32_OOP_Relationship
{
    public class Author
    {
        public Author(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        public string Name { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Nationality})";
        }
        //Navigation property
        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class Book
    {
        public Book(string title, Author author)
        {
            Title = title;
            Author = author;
        }

        public string Title { get; set; }
        public Author Author { get; set; }
        public Library Library { get; set; }
        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }

    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Library(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public override string ToString()
        {
            string books = "";
            foreach (var item in Books)
            {
                books += "\t- " + item.ToString() + "\n";
            }
            return $"Library: {Name} Books in the library:\n" + books;
        }
    }
}
