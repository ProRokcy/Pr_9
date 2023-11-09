using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
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
using System.Xml.Linq;
using ARVpr7.Model;

namespace ARVpr7.Pages.Librelist
{
    /// <summary>
    /// Логика взаимодействия для EditReaderPage.xaml
    /// </summary>
    public partial class EditReaderPage : Page
    {
        int idt;
        public EditReaderPage(Reader reder)
        {
            InitializeComponent();
            idt = reder.id;
            TxbName.Text = reder.name;
            TxbSurname.Text = reder.surname;
            TxPhone.Text = reder.phone;
            TxbAddress.Text = reder.address;
            TxbPatronymic.Text = reder.patronymic; 
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.GoBack();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var EditReader = OdbConnectHelper.entObj.Reader.FirstOrDefault(x => x.id == idt);
            try
            {
                if (TxbSurname.Text != ""
                    && TxbName.Text != ""
                    && TxbPatronymic.Text != ""
                    && TxbAddress.Text != ""
                    && TxPhone.Text != "")
                {

                    EditReader.surname = TxbSurname.Text;
                    EditReader.name = TxbName.Text;
                    EditReader.patronymic = TxbPatronymic.Text;
                    EditReader.address = TxbAddress.Text;
                    EditReader.phone = TxPhone.Text;

                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);
                    FrameApp.frameObj.Navigate(new ReaderViewPage());
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
           var DeleteReader = OdbConnectHelper.entObj.Reader.FirstOrDefault(x => x.id == idt);
            try
            {
              OdbConnectHelper.entObj.Reader.Remove(DeleteReader);
              OdbConnectHelper.entObj.SaveChanges();
              MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
              FrameApp.frameObj.Navigate(new ReaderViewPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
