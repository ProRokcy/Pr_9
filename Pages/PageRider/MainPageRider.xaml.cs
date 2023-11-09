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

namespace ARVpr7.Pages.PageRider
{
    /// <summary>
    /// Логика взаимодействия для MainPageRider.xaml
    /// </summary>
    public partial class MainPageRider : Page
    {
        public MainPageRider()
        {
            InitializeComponent();
        }

        private void RegPage_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new RegPageReader());
        }
        private void BookView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new BookPageReader());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new PageLogin());
        }
    }
}
