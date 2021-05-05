using CourseLibrary.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace CourseLibrary.Pages
{
    /// <summary>
    /// Логика взаимодействия для Books1.xaml
    /// </summary>
    public partial class Books1 : Page
    {
        public Books1()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();
        }

        /// <summary>
        ///  Поиск(фильтрация) данных по Имени поля
        /// </summary>

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<Book> books = BusinessLibraryEntities.GetContex().Books.ToList();
            books = books.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = books.ToList();
        }

        /// <summary>
        ///  Переход на страницу добавления записи
        /// </summary>

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.Pbook(null));
        }

        /// <summary>
        ///  Удаление записи
        /// </summary>

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Book>().ToList(); //Выделение полей для удаления 

            if (MessageBox.Show($"Вы точно хотите удалить следущие {ForRemoving.Count()} Элементов???", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    BusinessLibraryEntities.GetContex().Books.RemoveRange(ForRemoving);
                    BusinessLibraryEntities.GetContex().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        ///  Обновление данных на странице при добавление, удаление, редактирование!!!
        /// </summary>

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusinessLibraryEntities.GetContex().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();
            }
        }

        /// <summary>
        ///  Редактирование записи
        /// </summary>

        private void btn_bild_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.Pbook((sender as Button).DataContext as CourseLibrary.Book));
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Book>().ToList(); //Выделение полей для удаления 
            BusinessLibraryEntities.GetContex().Books.RemoveRange(ForRemoving);
            BusinessLibraryEntities.GetContex().SaveChanges();
        }

        /// <summary>
        /// Экспорт в отчёт Excel
        /// </summary>

        private void btn_excel_Click(object sender, RoutedEventArgs e)
        {
            var allusers = BusinessLibraryEntities.GetContex().Books.ToList().OrderBy(p => p.Name).ToList();

            var aplication = new Excel.Application();
            aplication.SheetsInNewWorkbook = allusers.Count();

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);
                
            int StartRowIndex = 1;

            for (int i = 0; i < allusers.Count(); i++)
            {
                Excel.Worksheet worksheets = aplication.Worksheets.Item[i+ 1];
                worksheets.Name = allusers[i].Name;

                worksheets.Cells[1][StartRowIndex] = "Имя";
                worksheets.Cells[2][StartRowIndex] = "Жанр";
                worksheets.Cells[3][StartRowIndex] = "Автор";
                worksheets.Cells[4][StartRowIndex] = "Колчиство страниц в книге";
                worksheets.Cells[5][StartRowIndex] = "Количество книг";

                StartRowIndex++;

                foreach (var date in BusinessLibraryEntities.GetContex().Books)
                {
                    worksheets.Cells[1][StartRowIndex] = date.Name;
                    worksheets.Cells[2][StartRowIndex] = date.Genre.Name;
                    worksheets.Cells[3][StartRowIndex] = date.Avtor.Name;
                    worksheets.Cells[4][StartRowIndex] = date.NumberOfLines;
                    worksheets.Cells[5][StartRowIndex] = date.Amount;   

                    StartRowIndex++;
                }

                worksheets.Columns.AutoFit();
            }

            aplication.Visible = true;
        }
    }
}
