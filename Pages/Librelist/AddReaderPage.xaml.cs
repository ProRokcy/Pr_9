using ARVpr7.Model;
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
    /// Логика взаимодействия для AddReaderPage.xaml
    /// </summary>
    public partial class AddReaderPage : Page
    {
        public AddReaderPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbSurname.Text != ""
                  && TxbName.Text != ""
                  && TxbPatronymic.Text != ""
                  && TxbAddress.Text != ""
                  && TxPhone.Text != "")
                {
                    Reader reader = new Reader()
                {
                    name = TxbName.Text,
                    surname = TxbSurname.Text,
                    patronymic = TxbPatronymic.Text,
                    address = TxbAddress.Text,
                    phone = TxPhone.Text,
                };
                OdbConnectHelper.entObj.Reader.Add(reader);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Читатель добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                FrameApp.frameObj.Navigate(new ReaderViewPage());
                }
                else
                {
                    MessageBox.Show("Пустые поля", "Уведомление", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критическая работа в приложении: " + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.GoBack();
        }
    }
}
