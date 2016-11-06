using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfBook.Model;

namespace WpfBook.ViewModel
{
    public class MainViewModel 
    {
        public ObservableCollection<BookViewModel> BookList { get; set; }

        public MainViewModel(List<Book> books)
        {
            BookList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        }
    }
}
