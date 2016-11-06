using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using WpfBook.Model;

namespace WpfBook.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public Book Book;

        public BookViewModel(Book book)
        {
            this.Book = book;
        }

        public int BookId
        {
            get { 
                return Book.BookId; 
            }
            set
            {
                Book.BookId = value;
                OnPropertyChanged("BookId");
            }
        }

        public string Title
        {
            get { return Book.Title; }
            set
            {
                Book.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Author
        {
            get { return Book.Author; }
            set
            {
                Book.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public string PublishDate
        {
            get { return Book.PublishDate.ToString(); }
            set
            {
                //Book.PublishDate = value;
                OnPropertyChanged("PublishDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
