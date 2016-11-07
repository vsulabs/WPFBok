using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfBook.Model
{
    public class Book
    {
        private static int bookCount = 1;
        public Book(string title, string author, DateTime publishDate)
        {
            this.BookId = bookCount++;
            this.Title = title;
            this.Author = author;
            this.PublishDate = publishDate;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }       
      
}
