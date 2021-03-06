﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfBook.Model;
using WpfBook.View;

namespace WpfBook.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
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

        private bool sortedByDate;
        public bool IsSorted
        {
            get
            {
                return sortedByDate;
            }

            set
            {
                sortedByDate = value;
                List<BookViewModel> books = BookList.ToList<BookViewModel>();
                Comparison<BookViewModel> byDate = (view1, view2) => view1.Book.PublishDate.CompareTo(view2.Book.PublishDate);
                Comparison<BookViewModel> byId = (view1, view2) => view1.Book.BookId.CompareTo(view2.Book.BookId);

                Comparison<BookViewModel> comparision = sortedByDate ? byDate : byId;
                books.Sort(comparision);

                BookList = new ObservableCollection<BookViewModel>(books);

                OnPropertyChanged("BookList");
            }
        }

        public MainViewModel(List<Book> books)
        {
            BookList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
            EventManager.RegisterClassHandler(typeof(ListBoxItem), 
                ListBoxItem.MouseLeftButtonDownEvent, 
                new RoutedEventHandler(OnMouseLeftButtonDown));
        }

        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            EditView window = new EditView();
            ListBoxItem item = (ListBoxItem)sender;
            BookViewModel f = (BookViewModel)item.DataContext;

            window.Closing += (o, args) =>
            {
                bool error = f.Title.Count() == 0;
                if (error)
                {
                    args.Cancel = true;
                }
            };

            window.DataContext = f;
            window.ShowDialog();
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
