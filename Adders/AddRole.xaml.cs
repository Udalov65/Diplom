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
    /// Логика взаимодействия для AddRole.xaml
    /// </summary>
    public partial class AddRole : Page
    {
        private Role currentRole = new Role();
        public AddRole(Role selectedRole)
        {
            InitializeComponent();
            if (selectedRole != null)
                currentRole = selectedRole;

            DataContext = currentRole;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentRole.RoleID == 0)
                SibStroyEntities.GetContext().Role.Add(currentRole);
            SibStroyEntities.GetContext().SaveChanges();

            AppFrame.frameMain.Navigate(new PageRoleAdmin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageRoleAdmin());
        }
    }
}
