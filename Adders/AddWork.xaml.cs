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
    /// Логика взаимодействия для AddWork.xaml
    /// </summary>
    public partial class AddWork : Page
    {
        private WorkOfOrders currentWork = new WorkOfOrders();
        public AddWork(WorkOfOrders selectedWork)
        {
            InitializeComponent();
            if (selectedWork != null)
                currentWork = selectedWork;
            currentWork.idOrder = HelpClass.id;
            DataContext = currentWork;

            NameWork.SelectedValuePath = "WorkID";
            //NameWork.ItemsSource = SibStroyEntities.GetContext().PriceWork.ToList();


            CategoryWork.SelectedValuePath = "CategoryID";
            CategoryWork.DisplayMemberPath = "CategoryName";
            CategoryWork.ItemsSource = SibStroyEntities.GetContext().CategoryWork.ToList();

        }

        private void AddButn_Click(object sender, RoutedEventArgs e)
        {
            if (currentWork.WorkOfOrdersID == 0)
                SibStroyEntities.GetContext().WorkOfOrders.Add(currentWork);
            SibStroyEntities.GetContext().SaveChanges();

            MagazineOrdersClients ZAKAZ = SibStroyEntities.GetContext().MagazineOrdersClients.FirstOrDefault(x => x.OrderID == HelpClass.id);
            AppFrame.frameMain.Navigate(new PageOfOrder(ZAKAZ));
        }

        private void CategoryWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int t = Convert.ToInt32(CategoryWork.SelectedValue);
            NameWork.ItemsSource = SibStroyEntities.GetContext().PriceWork.Where(x => x.idCategory == t).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }
}
