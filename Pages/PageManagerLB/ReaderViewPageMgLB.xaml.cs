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
    /// Логика взаимодействия для ReaderViewPageMgLB.xaml
    /// </summary>
    public partial class ReaderViewPageMgLB : Page
    {
        public ReaderViewPageMgLB()
        {
            InitializeComponent();
            GridList.ItemsSource = OdbConnectHelper.entObj.Reader.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.GoBack();
        }

        private void Tbx_serhc_TextChanged(object sender, TextChangedEventArgs e)
        {
            GridList.ItemsSource = OdbConnectHelper.entObj.Reader.Where(x => x.surname.Contains(Tbx_serhc.Text)).ToList();
        }
    }
}
