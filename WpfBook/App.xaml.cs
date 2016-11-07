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
                new Book("Скотный двор", "Дж. Оруэлл", new DateTime(1945, 1, 1)),
                new Book("Колобок", "", new DateTime(1610, 1, 1)),
                new Book("Война и мир", "Л.Н. Толстой", new DateTime(1869, 1, 1)),
                new Book("Отцы и дети", "И.С. Тургенев", new DateTime(1862, 1, 1)),
                new Book("Над пропостью во ржи", "Дж. Селенджер", new DateTime(1950, 1, 1)),
                new Book("Мастер и Маргарита", "М.А. Булгаков", new DateTime(1921, 1, 1)),
                new Book("Репка", "", new DateTime(1488, 1, 1)),
                new Book("1984", "Дж. Оруэлл", new DateTime(1949, 1, 1)),
                new Book("После балла", "Л.Н. Толстой", new DateTime(1850, 1, 1)),
                new Book("Шантарам", "Дж. Робертс", new DateTime(2013, 1, 1)),
                new Book("Глотнуть воздуха", "Дж. Оруэлл", new DateTime(1939, 1, 1))

            };

            MainView view = new MainView();
            MainViewModel viewModel = new MainViewModel(books);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
