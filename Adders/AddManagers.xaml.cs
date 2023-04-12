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
    /// Логика взаимодействия для AddManagers.xaml
    /// </summary>
    public partial class AddManagers : Page
    {
        private Managers currentManagers = new Managers();
        public AddManagers(Managers selectedManagers)
        {
            InitializeComponent();
            if (selectedManagers != null)
                currentManagers = selectedManagers;

            DataContext = currentManagers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentManagers.ManagerID == 0)
                SibStroyEntities.GetContext().Managers.Add(currentManagers);
            SibStroyEntities.GetContext().SaveChanges();

            AppFrame.frameMain.Navigate(new PageManagerAdmin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageManagerAdmin());
        }
    }
}
