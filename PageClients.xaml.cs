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
using Diplom.Adders;
using Diplom.ApplicationData;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        public PageClients()
        {
            InitializeComponent();
            Клиенты.ItemsSource = SibStroyEntities.GetContext().Clients.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageManager());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddClients(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var removeClients = Клиенты.SelectedItem as Clients;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().Clients.Remove(removeClients);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Клиенты.ItemsSource = SibStroyEntities.GetContext().Clients.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
            }
        }

        private void BtnSelectClient1_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddClients((sender as Button).DataContext as Clients));
        }

    }
    }

