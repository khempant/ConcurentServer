using System;

namespace ClassLibrary1
{
    public class Book
    {
        private string title;
        private string author;
        private int pageNumber;
        private string isbn13;
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageNumber { get; set; }
        public string Isbn13 { get; set; }
        public Book(string title, string author, int pageNumber, string isbn13)
        {
            Title = title;
            Author = author;
            PageNumber = pageNumber;
            Isbn13 = isbn13;
        }
        public override string ToString()
        {
            return $"{Title}-{Author}-{PageNumber}-{Isbn13}";
        }
    }
}
