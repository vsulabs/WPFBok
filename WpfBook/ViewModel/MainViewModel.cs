using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using WpfBook.Model;

namespace WpfBook.ViewModel
{
    public class MainViewModel 
    {
        public ObservableCollection<BookViewModel> BookList { get; set; }
        public string PublishDate
        {
            get {
                return BookViewModel.SearchDate;
            }
            set {
                BookViewModel.SearchDate = value;
                foreach (BookViewModel model in BookList)
                {
                    model.Update();
                }
            }
        }
       
        public MainViewModel(List<Book> books)
        {
            BookList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
        }
    }
}
