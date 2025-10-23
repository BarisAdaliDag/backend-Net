using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Raletionship
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
        public List<Book> Books { get; set; }
        public override string ToString()
        {
            return $"{Name} {Nationality}";

        }

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
        public Library(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }

        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public override string ToString()
        {
            String books = "";
            foreach (var item in Books)
            {
                books += "\t " + item.ToString() + '\n';
            }
            return $" Library {Name} books in library\n{books}";
        }
    }
   

}
