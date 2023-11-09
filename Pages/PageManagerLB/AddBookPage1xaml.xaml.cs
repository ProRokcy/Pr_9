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
using ARVpr7.Model;

namespace ARVpr7.Pages.PageManagerLB
{
    /// <summary>
    /// Логика взаимодействия для AddBookPage1xaml.xaml
    /// </summary>
    public partial class AddBookPage1xaml : Page
    {
        public AddBookPage1xaml()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbAuthor.Text != ""
                  && TxbTitle.Text != "")
                {
                    Book book = new Book()
                    {
                       autor = TxbAuthor.Text,
                       title = TxbTitle.Text,
                    };
                    OdbConnectHelper.entObj.Book.Add(book);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Книга добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frameObj.Navigate(new BookViewPageMgLB());
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
            FrameApp.frameObj.Navigate(new BookViewPageMgLB());
        }
    }
}
