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

namespace Diplom.Adders
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerAdmin.xaml
    /// </summary>
    public partial class AddWorkerAdmin : Page
    {
        private Worker currentWorkers = new Worker();
        public AddWorkerAdmin(Worker selectedWorkers)
        {
            InitializeComponent();
            if (selectedWorkers != null)
                currentWorkers = selectedWorkers;

            DataContext = currentWorkers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentWorkers.WorkerID == 0)
                SibStroyEntities.GetContext().Worker.Add(currentWorkers);
            SibStroyEntities.GetContext().SaveChanges();
            AppFrame.frameMain.Navigate(new PageWorkerAdmin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageWorkerAdmin());
        }
    }
}
