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
    /// Логика взаимодействия для PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public PageManager()
        {
            InitializeComponent();
        }

        private void BtnHouse_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new TypeOfBuild.TypeHouse());
        }



        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageClients());
        }

        private void BtnMagazineOrder_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMagazineClients());
        }

        private void BtnPriceWork_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PagePriceWork());
        }

        private void BtnObject_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageObject());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageLogin());
        }
    }
}
