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

namespace ARVpr7.Pages.PageManagerLB
{
    /// <summary>
    /// Логика взаимодействия для BookViewPageMgLB.xaml
    /// </summary>
    public partial class BookViewPageMgLB : Page
    {
        public BookViewPageMgLB()
        {
            InitializeComponent();
            GridList.ItemsSource = OdbConnectHelper.entObj.Book.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new MainPageManager());
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            dynamic k = (sender as Button).DataContext;
            FrameApp.frameObj.Navigate(new EditBookPageMgLB(k));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new AddBookPage1xaml());
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            GridList.ItemsSource = OdbConnectHelper.entObj.Book.Where(x => x.title.Contains(Tbx_serhc.Text)).ToList();
        }
    }
}
