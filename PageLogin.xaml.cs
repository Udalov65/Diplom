using Diplom.ApplicationData;
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

namespace Diplom
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model0db.User.FirstOrDefault(x => x.UserLogin == txbLogin.Text && x.UserPassword == psbBox.Text);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя не существует!", "Ошибка при авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.UserRole)
                    {
                        case 1:
                            MessageBox.Show("Приветствуем вас на странице администратора " + userObj.UserName + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameMain.Navigate(new PageAdmin());
                            break;
                        case 2:
                            MessageBox.Show("Приветствуем вас на странице менеджера " + userObj.UserName + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameMain.Navigate(new PageManager());
                            break;


                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void psbBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
 }

