using Diplom.ApplicationData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Diplom.Adders
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Page
    {
        private Clients currentClients = new Clients();
        public AddClients(Clients selectedClients)
        {
            InitializeComponent();            if (selectedClients != null)            currentClients = selectedClients;

            DataContext = currentClients;

        }

        private void AddButn_Click(object sender, RoutedEventArgs e)
        {
            if (currentClients.ClientID == 0)
                SibStroyEntities.GetContext().Clients.Add(currentClients);
            SibStroyEntities.GetContext().SaveChanges();
            AppFrame.frameMain.Navigate(new PageClients());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageClients());
        }
    }
}
