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
    /// Логика взаимодействия для PageManagerAdmin.xaml
    /// </summary>
    public partial class PageManagerAdmin : Page
    {
        public PageManagerAdmin()
        {
            InitializeComponent();
            Менеджер.ItemsSource = SibStroyEntities.GetContext().Managers.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddManagers(null));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdmin());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var removeManagers = Менеджер.SelectedItem as Managers;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().Managers.Remove(removeManagers);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Менеджер.ItemsSource = SibStroyEntities.GetContext().Managers.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
                //if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                //{
                //    var removeManagers = Менеджер.SelectedItem as Managers;
                //    AppConnect.model0db.Managers.Remove(removeManagers);
                //    AppConnect.model0db.SaveChanges();
                //    Менеджер.ItemsSource = AppConnect.model0db.Managers.ToList();
                //    MessageBox.Show("Успешно удалено");
                //}
                //else
                //{
                //    MessageBox.Show("В таблице нет информации!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }

        private void BtnSelectManager_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddManagers((sender as Button).DataContext as Managers));
        }
    }
}
