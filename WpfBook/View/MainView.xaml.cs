using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfBook.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        public object SelectedItem
        {
            get { return BookGrid.SelectedItem; }
        }

        public void OnRowClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
                return;

            EditView view = new EditView();
            view.DataContext = this;
            view.ShowDialog();
        }
    }
}
