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

namespace ARVpr7.Pages.Librelist
{
    /// <summary>
    /// Логика взаимодействия для EditRegPage.xaml
    /// </summary>
    public partial class EditRegPage : Page
    {
        int Id;
        public EditRegPage(Registration registration)
        {
            InitializeComponent();
            CmbBook.DisplayMemberPath = "title";
            CmbBook.SelectedValuePath = "id";
            CmbBook.ItemsSource = OdbConnectHelper.entObj.Book.ToList();

            CmbReader.DisplayMemberPath = "surname";
            CmbReader.SelectedValuePath = "id";
            CmbReader.ItemsSource = OdbConnectHelper.entObj.Reader.ToList();
            Id = registration.id;
            CmbBook.SelectedValue = registration.id_book;
            CmbReader.SelectedValue = registration.id_reader;
            PlannedData.SelectedDate = registration.planned_date_of_issue;
            ActualData.SelectedDate = registration.actual_date_of_issue;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var EditReg = OdbConnectHelper.entObj.Registration.FirstOrDefault(x => x.id == Id);
            try
            {
                if (CmbBook.SelectedValue != null
                       && CmbReader.SelectedValue != null
                       && PlannedData.SelectedDate != null
                       && ActualData.SelectedDate != null)
                {

                    EditReg.id_book = Convert.ToInt32(CmbBook.SelectedValue);
                    EditReg.id_reader = Convert.ToInt32(CmbReader.SelectedValue);
                    EditReg.planned_date_of_issue = (DateTime)PlannedData.SelectedDate;
                    EditReg.actual_date_of_issue = (DateTime)ActualData.SelectedDate;

                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Информация изменена", "Уведомление", MessageBoxButton.OK);
                    FrameApp.frameObj.Navigate(new RegViewPage());
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObj.Navigate(new RegViewPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var DeleteReg = OdbConnectHelper.entObj.Registration.FirstOrDefault(x => x.id == Id);
            try
            {
                OdbConnectHelper.entObj.Registration.Remove(DeleteReg);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Информация удалена и сохранена", "Уведомление", MessageBoxButton.OK);
                FrameApp.frameObj.Navigate(new RegViewPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
