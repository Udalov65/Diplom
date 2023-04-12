using Diplom.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для PagePriceWork.xaml
    /// </summary>
    public partial class PagePriceWork : Page
    {
        public PagePriceWork()
        {
            InitializeComponent();
            Filtration.SelectedValuePath = "CategoryID";
            Filtration.DisplayMemberPath = "CategoryName";
            Filtration.ItemsSource = SibStroyEntities.GetContext().CategoryWork.ToList();
            ПрайсЛист.ItemsSource = SibStroyEntities.GetContext().PriceWork.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageManager());
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
           
            var Category = AppConnect.modelOdb.CategoryWork.OrderBy(x => x.CategoryName).ToList();

            var application = new Excel.Application();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            Excel.Worksheet worksheet = application.Worksheets.Item[1];

            int RowIndex = 6;
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[4, 4]];
            Excel.Range headr = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[50, 1]];

            header.Font.Bold = true;

            headr.Font.Bold = true;


            worksheet.Cells[2][1] = "ООО СИБ-СТРОЙ";
            worksheet.Cells[2][2] = "Прайс-лист";
            worksheet.Cells[3][2] = DateTime.Now.ToLongDateString();

            worksheet.Cells[1][4] = "Категория";
            worksheet.Cells[2][4] = "Работа";
            worksheet.Cells[3][4] = "Единица";
            worksheet.Cells[4][4] = "Цена";

            foreach (var item in Category)
            {
                var Spisok = AppConnect.modelOdb.PriceWork.Where(x => x.idCategory == item.CategoryID).ToList();
                worksheet.Cells[1][RowIndex] = item.CategoryName;
                for (int i = 0; i < Spisok.Count(); i++)
                {

                    worksheet.Cells[2][RowIndex] = Spisok[i].Работа;
                    worksheet.Cells[3][RowIndex] = Spisok[i].Единица;
                    worksheet.Cells[4][RowIndex] = Spisok[i].Цена;
                    worksheet.Columns.AutoFit();

                    RowIndex++;
                }
                RowIndex++;
            }
            application.Visible = true;

        }
        int T;
        private void Filtration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            T = Convert.ToInt32(Filtration.SelectedValue);
            Filtr();
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtr();
        }
        private void Filtr()
        {
            var SearchList = SibStroyEntities.GetContext().PriceWork.ToList();

            if (Filtration.SelectedIndex>-1)
            {
                
                SearchList = SearchList.Where(x => x.idCategory == T).ToList();
            }
            if (Poisk.Text != "")
            {
                SearchList = SearchList.Where(x => x.Работа.ToLower().Contains(Poisk.Text.ToLower())).ToList();
            }

            ПрайсЛист.ItemsSource = SearchList.ToList();
        }
    }
    }

