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
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Page
    {
        private User currentUsers = new User();
        public AddUsers(User selectedUsers)
        {
            InitializeComponent();
            if (selectedUsers != null)
                currentUsers = selectedUsers;

            DataContext = currentUsers;
        }

        private void AddButn_Click(object sender, RoutedEventArgs e)
        {
            if (currentUsers.UserID == 0)
                SibStroyEntities.GetContext().User.Add(currentUsers);
            SibStroyEntities.GetContext().SaveChanges();

            AppFrame.frameMain.Navigate(new PageUserAdmin());
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageUserAdmin());
        }
    }
}
