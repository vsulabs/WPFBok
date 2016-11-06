using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfBook.Model
{
    public class Book
    {
        public Book(int id, string title, string author, DateTime publishDate)
        {
            this.BookId = id;
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
