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
    /// Логика взаимодействия для PageWorkerAdmin.xaml
    /// </summary>
    public partial class PageWorkerAdmin : Page
    {
        public PageWorkerAdmin()
        {
            InitializeComponent();
            Работник.ItemsSource = SibStroyEntities.GetContext().Worker.ToList();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdmin());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            //var removeWorker = Работник.SelectedItems.Cast<Worker>().ToList();
            var removeWorker = Работник.SelectedItem as Worker;
            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().Worker.Remove(removeWorker);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Работник.ItemsSource = SibStroyEntities.GetContext().Worker.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }

            }
        }
        //var removeWorker = Работник.SelectedItem as Worker;
        //AppConnect.model0db.Worker.Remove(removeWorker);
        //AppConnect.model0db.SaveChanges();
        //Работник.ItemsSource = AppConnect.model0db.Worker.ToList();
        //MessageBox.Show("Успешно удалено");
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddWorkerAdmin(null));
        }

        private void BtnSelectWorker_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddWorkerAdmin((sender as Button).DataContext as Worker));
        }
    }
}
