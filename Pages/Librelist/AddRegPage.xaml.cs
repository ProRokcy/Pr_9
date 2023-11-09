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
    /// Логика взаимодействия для AddRegPage.xaml
    /// </summary>
    public partial class AddRegPage : Page
    {
        public AddRegPage()
        {
            InitializeComponent();
           
            CmbBook.DisplayMemberPath = "title";
            CmbBook.SelectedValuePath = "id";
            CmbBook.ItemsSource = OdbConnectHelper.entObj.Book.ToList();

            CmbReader.DisplayMemberPath = "surname";
            CmbReader.SelectedValuePath = "id";
            CmbReader.ItemsSource = OdbConnectHelper.entObj.Reader.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbBook.SelectedValue != null
                  &&CmbReader.SelectedValue != null
                  && PlannedData.SelectedDate != null
                  && ActualData.SelectedDate != null)
                {
                    Registration registration = new Registration()
                    {
                        id_book = Convert.ToInt32(CmbBook.SelectedValue),
                        id_reader = Convert.ToInt32(CmbReader.SelectedValue),
                        planned_date_of_issue = (DateTime)PlannedData.SelectedDate,
                        actual_date_of_issue = (DateTime)ActualData.SelectedDate,
                    };
                    OdbConnectHelper.entObj.Registration.Add(registration);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Регистрация добавлена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frameObj.Navigate(new RegViewPage());
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
            FrameApp.frameObj.Navigate(new RegViewPage());
        }
    }
}
