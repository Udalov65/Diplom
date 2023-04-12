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
    /// Логика взаимодействия для PageMagazineClients.xaml
    /// </summary>
    public partial class PageMagazineClients : Page
    {
        public PageMagazineClients()
        {

            InitializeComponent();
            Журнал.ItemsSource = SibStroyEntities.GetContext().MagazineOrdersClients.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageManager());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddMagazineClients(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removeMagazine = Журнал.SelectedItem as MagazineOrdersClients;

            if (MessageBox.Show("Вы действительно хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SibStroyEntities.GetContext().MagazineOrdersClients.Remove(removeMagazine);
                    SibStroyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    Журнал.ItemsSource = SibStroyEntities.GetContext().MagazineOrdersClients.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
            }
        }

        private void BtnSelectOrder_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Adders.AddMagazineClients((sender as Button).DataContext as MagazineOrdersClients));
        }

        private void BtnSelectOrder_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageOfOrder((sender as Button).DataContext as MagazineOrdersClients));
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void BtnSelectOtchet_Click(object sender, RoutedEventArgs e)
        {
            MagazineOrdersClients order = (sender as Button).DataContext as MagazineOrdersClients;
            var wordApp = new Word.Application();
            Word.Document document = wordApp.Documents.Open(@"C:\Users\Sizz\Downloads\Dogovor3.docx");

            ReplaceWordStub("{OrderID}", order.OrderID.ToString(), document);
            Clients clients = new Clients();
            clients = SibStroyEntities.GetContext().Clients.FirstOrDefault(x => x.ClientID == order.idClient);
            ReplaceWordStub("{Client}", clients.ФИО, document);
            ReplaceWordStub("{Date}", DateTime.Now.ToShortDateString(), document);
            ReplaceWordStub("{Adres}", clients.Адрес, document);
            ReplaceWordStub("{NumberPhone}", clients.Номер_телефона, document);
            ReplaceWordStub("{Pasport}", clients.Паспортные_данные, document);
            ReplaceWordStub("{DataVidachi}", clients.Паспортные_данные, document);
            ReplaceWordStub("{Adres2}", clients.Адрес, document);
            ReplaceWordStub("{Client2}", clients.ФИО, document);
            wordApp.Visible = true;
        }
    }
}
