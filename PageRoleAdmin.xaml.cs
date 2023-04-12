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
    /// Логика взаимодействия для PageRoleAdmin.xaml
    /// </summary>
    public partial class PageRoleAdmin : Page
    {
        public PageRoleAdmin()
        {
            InitializeComponent();
            Роли.ItemsSource = SibStroyEntities.GetContext().Role.ToList();
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var removeRoles = Роли.SelectedItem as Role;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().Role.Remove(removeRoles);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Роли.ItemsSource = SibStroyEntities.GetContext().Role.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
                //    if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                //{
                //    var removeRole = Роли.SelectedItem as Role;
                //    AppConnect.model0db.Role.Remove(removeRole);
                //    AppConnect.model0db.SaveChanges();
                //    Роли.ItemsSource = AppConnect.model0db.Role.ToList();
                //    MessageBox.Show("Успешно удалено");
                //}
                //else
                //{
                //    MessageBox.Show("В таблице нет информации!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }   
            private void BtnBack_Click(object sender, RoutedEventArgs e)
            {
                AppFrame.frameMain.Navigate(new PageAdmin());
            }

            private void BtnAdd_Click(object sender, RoutedEventArgs e)
            {
                AppFrame.frameMain.Navigate(new Adders.AddRole(null));
            }       
    private void BtnSelectRole_Click(object sender, RoutedEventArgs e)
    {
            AppFrame.frameMain.Navigate(new AddRole((sender as Button).DataContext as Role));
    }
    }
 }

