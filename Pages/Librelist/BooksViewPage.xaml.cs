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
    /// Логика взаимодействия для BooksViewPage.xaml
    /// </summary>
    public partial class BooksViewPage : Page
    {
        public BooksViewPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GridList.ItemsSource = OdbConnectHelper.entObj.Book.ToList();
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            GridList.ItemsSource = OdbConnectHelper.entObj.Book.Where(x => x.title.Contains(Tbx_serhc.Text)).ToList();
        }
    }
}
