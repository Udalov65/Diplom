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
    /// Логика взаимодействия для AddPriceAdmin.xaml
    /// </summary>
    public partial class AddPriceAdmin : Page
    {
        private PriceWork currentWork = new PriceWork();
        public AddPriceAdmin(PriceWork selectedWork)
        {
            InitializeComponent();
            if (selectedWork != null)
                currentWork = selectedWork;
            DataContext = currentWork;

            Category.ItemsSource = SibStroyEntities.GetContext().CategoryWork.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentWork.WorkID == 0)
                SibStroyEntities.GetContext().PriceWork.Add(currentWork);
            SibStroyEntities.GetContext().SaveChanges();

            AppFrame.frameMain.Navigate(new PagePriceWorkAdmin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PagePriceWorkAdmin());
        }
    }
}
