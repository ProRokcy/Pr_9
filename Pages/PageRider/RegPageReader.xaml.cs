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
    /// Логика взаимодействия для RegPageReader.xaml
    /// </summary>
    public partial class RegPageReader : Page
    {
        public RegPageReader()
        {
            InitializeComponent();
            GridList1.ItemsSource = OdbConnectHelper.entObj.Registration.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.GoBack();
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            GridList1.ItemsSource = OdbConnectHelper.entObj.Registration.Where(x => x.Reader.surname.Contains(Tbx_serhc.Text)
        || x.Book.title.Contains(Tbx_serhc.Text)).ToList();
        }
    }
}
