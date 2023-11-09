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
    /// Логика взаимодействия для ReaderViewPage.xaml
    /// </summary>
    public partial class ReaderViewPage : Page
    {
        public ReaderViewPage()
        {
            InitializeComponent();
            GridList.ItemsSource = OdbConnectHelper.entObj.Reader.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new MainPageLibralist());
        }

        private void BtnAddReader_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new AddReaderPage());
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            dynamic k = (sender as Button).DataContext;
            FrameApp.frameObj.Navigate(new EditReaderPage(k));
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {

            GridList.ItemsSource = OdbConnectHelper.entObj.Reader.Where(x => x.surname.Contains(Tbx_serhc.Text)).ToList();
        }
    }
}
