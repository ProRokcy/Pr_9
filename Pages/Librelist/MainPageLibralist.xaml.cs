using ARVpr7.Pages.PageRider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARVpr7.Pages.Librelist
{
    /// <summary>
    /// Логика взаимодействия для MainPageLibralist.xaml
    /// </summary>
    public partial class MainPageLibralist : Page
    {
        public MainPageLibralist()
        {
            InitializeComponent();
        }

        private void BookView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new BooksViewPage());
        }

        private void ReaderView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new ReaderViewPage());
        }

        private void RegPage_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new RegViewPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new PageLogin());
        }
    }
}
