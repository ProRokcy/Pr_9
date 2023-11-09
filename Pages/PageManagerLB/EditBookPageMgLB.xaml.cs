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
    /// Логика взаимодействия для EditBookPageMgLB.xaml
    /// </summary>
    public partial class EditBookPageMgLB : Page
    {
        int Id;
        public EditBookPageMgLB(Book book)
        {
            InitializeComponent();
            Id = book.id;
            TxbTitle.Text = book.title;
            TxbAuthor.Text = book.autor;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new BookViewPageMgLB());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var EditBook = OdbConnectHelper.entObj.Book.FirstOrDefault(x => x.id == Id);
            try
            {
                if (TxbAuthor.Text != ""
                   && TxbTitle.Text != "")
                {

                    EditBook.autor = TxbAuthor.Text;
                    EditBook.title = TxbTitle.Text;

                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frameObj.Navigate(new BookViewPageMgLB());
                }
                else
                {
                    MessageBox.Show("Пустые поля", "Уведомление", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var DeleteBook = OdbConnectHelper.entObj.Book.FirstOrDefault(x => x.id == Id);
            try
            {
                OdbConnectHelper.entObj.Book.Remove(DeleteBook);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frameObj.Navigate(new BookViewPageMgLB());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
