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
    /// Логика взаимодействия для PagePriceWorkAdmin.xaml
    /// </summary>
    public partial class PagePriceWorkAdmin : Page
    {
        public PagePriceWorkAdmin()
        {
            InitializeComponent();
            ПрайсВорк.ItemsSource = SibStroyEntities.GetContext().PriceWork.ToList();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddPriceAdmin(null));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAdmin());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            //var removePrice = ПрайсВорк.SelectedItems.Cast<PriceWork>().ToList();
            var removePrice = ПрайсВорк.SelectedItem as PriceWork;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().PriceWork.Remove(removePrice);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    ПрайсВорк.ItemsSource = SibStroyEntities.GetContext().PriceWork.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
            }
        }

        private void BtnSelectWork_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddPriceAdmin((sender as Button).DataContext as PriceWork));
        }
    }
}
