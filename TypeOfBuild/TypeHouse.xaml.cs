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

namespace Diplom.TypeOfBuild
{
    /// <summary>
    /// Логика взаимодействия для TypeHouse.xaml
    /// </summary>
    public partial class TypeHouse : Page
    {
        public TypeHouse()
        {
            InitializeComponent();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(tbLong.Text);
            double b = Convert.ToDouble(tbWidth.Text);
            double h = Convert.ToDouble(tbHigh.Text);

            double p = (a + b) * 2;
            double s = (a * b);
            double s2 = (p * h);

            tbPerimetr.Text = Convert.ToString(p);
            tbPloshad.Text = Convert.ToString(s);
            tbPloshadSten.Text = Convert.ToString(s2);
        }

        private void tbHigh_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbLong_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbPerimetr_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
