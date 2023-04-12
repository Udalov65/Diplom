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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void BtnPriceWork_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PagePriceWorkAdmin());
        }

        private void BtnRole_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageRoleAdmin());
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageUserAdmin());
        }

        private void BtnManager_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageManagerAdmin());
        }

        private void BtnWorker_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageWorkerAdmin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageLogin());
        }
    }
}
