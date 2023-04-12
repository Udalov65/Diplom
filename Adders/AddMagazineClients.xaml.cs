using Diplom.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace Diplom.Adders
{
    /// <summary>
    /// Логика взаимодействия для AddMagazineClients.xaml
    /// </summary>
    public partial class AddMagazineClients : Page
    {
        private MagazineOrdersClients currentOrder = new MagazineOrdersClients();   
        public AddMagazineClients(MagazineOrdersClients selectedOrder)
        {
            InitializeComponent();
            if (selectedOrder != null)
                currentOrder = selectedOrder;
            else
            {
                currentOrder.Дата_приема = DateTime.Now;
                currentOrder.Дата_сдачи = DateTime.Now;
            }
            DataContext = currentOrder;

            FIO.ItemsSource = SibStroyEntities.GetContext().Clients.ToList();
            Manager.ItemsSource = SibStroyEntities.GetContext().Managers.ToList();
            Worker.ItemsSource = SibStroyEntities.GetContext().Worker.ToList();

        }

        private void AddButn_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder.OrderID == 0)
                SibStroyEntities.GetContext().MagazineOrdersClients.Add(currentOrder);
            SibStroyEntities.GetContext().SaveChanges();

            AppFrame.frameMain.Navigate(new PageMagazineClients());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMagazineClients());
        }
    }
}
