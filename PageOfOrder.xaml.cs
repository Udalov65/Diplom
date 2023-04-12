using Diplom.Adders;
using Diplom.ApplicationData;
using Word = Microsoft.Office.Interop.Word;
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
    /// Логика взаимодействия для PageOfOrder.xaml
    /// </summary>
    public partial class PageOfOrder : System.Windows.Controls.Page
    {
        public PageOfOrder(MagazineOrdersClients order)
        {
            InitializeComponent();
            Zakaz.Text = order.OrderID.ToString();
            HelpClass.id = order.OrderID;
            HelpClass.Dt = order.Дата_приема;
            СоставЗаказа.ItemsSource = SibStroyEntities.GetContext().WorkOfOrders.Where(x=>x.idOrder == order.OrderID).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageMagazineClients());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeOrderClients = СоставЗаказа.SelectedItem as WorkOfOrders;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().WorkOfOrders.Remove(removeOrderClients);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    СоставЗаказа.ItemsSource = SibStroyEntities.GetContext().WorkOfOrders.Where(x => x.idOrder == HelpClass.id).ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddWork(null));
        }

        private void BtnSelectOrder2323_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddWork((sender as Button).DataContext as WorkOfOrders));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (Visibility == Visibility.Visible)
            //{
            //    SibStroyEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            //    СоставЗаказа.ItemsSource = SibStroyEntities.GetContext().WorkOfOrders.Where(x=>x.idOrder == order.OrderID).ToList();
            //}
        }

        private void BtnSmeta_Click(object sender, RoutedEventArgs e)
        {


            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph titleParagrapth = document.Paragraphs.Add();
            Word.Range titleRange = titleParagrapth.Range;
            titleRange.Text = "\t \t \t ООО ῝Сиб-строй῝ ";
            titleParagrapth.set_Style("Заголовок");
            titleRange.InsertParagraphAfter();

            Word.Paragraph priceParagrapth = document.Paragraphs.Add();
            Word.Range priceRange = priceParagrapth.Range;
            priceRange.Text = "Приложение 1 к Договору № "+ HelpClass.id.ToString()+ " От "+ HelpClass.Dt.ToLongDateString();
            //priceParagrapth.set_Style("Выделенная цитата");
            priceRange.InsertParagraphAfter();


            //Word.Paragraph userParagrapth = document.Paragraphs.Add();
            //Word.Range userRange = userParagrapth.Range;
            //userRange.Text = type.ComplectType;
            //userParagrapth.set_Style("Заголовок 1");
            //userRange.InsertParagraphAfter();

            var allWorks = SibStroyEntities.GetContext().WorkOfOrders.Where(x => x.idOrder == HelpClass.id).ToList();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, allWorks.Count() + 1, 4);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                    = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;


                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Наименование";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "Цена";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Объем работ";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Стоимость";


            paymentsTable.Rows[1].Range.Bold = 1;
                paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                double Summa = 0;
                for (int i = 0; i < allWorks.Count(); i++)
                {
                    var currentComplects = allWorks[i];

                    Summa += currentComplects.Cost;

                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = currentComplects.PriceWork.Работа;

                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = currentComplects.PriceWork.Цена.ToString();

                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = currentComplects.Count.ToString();

                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = currentComplects.Cost.ToString();
                }

            Word.Paragraph SummaParagrapth = document.Paragraphs.Add();
            Word.Range SummaRange = SummaParagrapth.Range;
            SummaRange.Text = "Всего к оплате: " + Summa.ToString()+ " руб";
            SummaRange.InsertParagraphAfter(); //Вывод даты в конце листа


            Word.Paragraph dateParagrapth = document.Paragraphs.Add();
            Word.Range dateRange = dateParagrapth.Range;
            dateRange.Text = "ЗАКАЗЧИК_________________________                            ИСПОЛНИТЕЛЬ _______________________";
            dateRange.InsertParagraphAfter(); //Вывод даты в конце листа

            application.Visible = true; // Пункт ошибкиvar allType = DataCenterDBEntities.GetContext().ComplectTypeTables.ToList();
        }
    }
}
