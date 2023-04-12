using Diplom.Adders;
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
    /// Логика взаимодействия для PageUserAdmin.xaml
    /// </summary>
    public partial class PageUserAdmin : Page
    {
        public PageUserAdmin()
        {
            InitializeComponent();
            Пользователи.ItemsSource = SibStroyEntities.GetContext().User.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdmin());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var removeUsers = Пользователи.SelectedItem as User;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().User.Remove(removeUsers);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Пользователи.ItemsSource = SibStroyEntities.GetContext().User.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
                //if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                //{
                //    var removeUsers = Пользователи.SelectedItem as User;
                //    AppConnect.model0db.User.Remove(removeUsers);
                //    AppConnect.model0db.SaveChanges();
                //    Пользователи.ItemsSource = AppConnect.model0db.User.ToList();
                //    MessageBox.Show("Успешно удалено");
                //}
                //else
                //{
                //    MessageBox.Show("В таблице нет информации!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddUsers(null));
        }
        private void BtnSelectUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddUsers((sender as Button).DataContext as User));
        }
    }
}
