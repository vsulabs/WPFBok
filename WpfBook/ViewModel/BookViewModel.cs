using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using WpfBook.Model;
using System.Globalization;

namespace WpfBook.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        public Book Book;
        public static string SearchDate { get; set; }

        public void Update()
        {
            OnPropertyChanged("RelatedDate");
        }

        public BookViewModel(Book book)
        {
            this.Book = book;
        }

        public enum RelatedDateType
        {
            Newer = 1, Equal = 0, Older = -1, None = 2
        }

        private RelatedDateType getRelatedDate(string searchDate)
        {
            DateTime date = new DateTime();
            CultureInfo info = CultureInfo.InvariantCulture;
            bool succes = DateTime.TryParse(searchDate, out date);
            if (!succes) {
                succes = DateTime.TryParseExact(searchDate, "yyyy", info, DateTimeStyles.AssumeLocal, out date);
                if (!succes)
                    return RelatedDateType.None;
            }

            if (date > Book.PublishDate)
                return RelatedDateType.Newer;
            else if (date == Book.PublishDate)
                return RelatedDateType.Equal;
            else
                return RelatedDateType.Older;
        }

        private RelatedDateType getRelatedDate(string searchDate1, string searchDate2)
        {
            RelatedDateType t1 = getRelatedDate(searchDate1);
            RelatedDateType t2 = getRelatedDate(searchDate2);

            if (t1 == RelatedDateType.None || t2 == RelatedDateType.None)
                return RelatedDateType.None;

            if (t1 == t2)
                return t1;

            if (t1 >= 0 && 0 >= t2 ||
                t1 <= 0 && 0 <= t2)
                return RelatedDateType.Equal;

            return RelatedDateType.None;
        }

        public RelatedDateType RelatedDate
        {
            get {
                if (SearchDate == null)
                    return RelatedDateType.None;

                string[] dates = SearchDate.Split('-');
                if (dates.Length == 1)
                    return getRelatedDate(dates[0]);
                else if (dates.Length == 2)
                    return getRelatedDate(dates[0], dates[1]);
                else
                    return RelatedDateType.None;
            }
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

        public DateTime PublishDate
        {
            get { 
                return Book.PublishDate; 
            }
            set {
                Book.PublishDate = value;
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
