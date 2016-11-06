using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using WpfBook.Model;
using WpfBook.ViewModel;
using WpfBook.View;

namespace WpfBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            List<Book> books = new List<Book>()
            {
                new Book(1, "Колобок", "", new DateTime(1610, 1, 1)),
                new Book(2, "Война и мир", "Л.Н. Толстой", new DateTime(1869, 1, 1)),
                new Book(3, "Отцы и дети", "И.С. Тургенев", new DateTime(1862, 1, 1))
            };

            MainView view = new MainView();
            MainViewModel viewModel = new MainViewModel(books);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
