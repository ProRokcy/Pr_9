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
using ARVpr7.Pages.Librelist;
using ARVpr7.Pages.PageManagerLB;
using ARVpr7.Pages.PageRider;


namespace ARVpr7.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectHelper.entObj.Users.FirstOrDefault(
                    x => x.login == TxbLogin.Text && x.password == PsbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нету!", "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);  
                }
                else
                {
                    PsbPassword.Password = userObj.password;
                    TxbLogin.Text = userObj.login;
                    switch (userObj.id_role)
                    {
                        case 1:
                            FrameApp.frameObj.Navigate(new MainPageManager());
                            break;
                        case 2:
                            FrameApp.frameObj.Navigate(new MainPageLibralist());
                            break;
                        case 3:
                            FrameApp.frameObj.Navigate(new MainPageRider());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Уведомление" + ex.Message.ToString(),
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
