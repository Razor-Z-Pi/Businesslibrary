using CourseLibrary.Class;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace CourseLibrary.Pages
{
    /// <summary>
    /// Логика взаимодействия для Genre.xaml
    /// </summary>
    public partial class Genre : Page
    {
        public Genre()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Genre.ToList();
        }

        /// <summary>
        ///  Поиск(фильтрация) данных по Имени поля
        /// </summary>

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<CourseLibrary.Genre> genres = BusinessLibraryEntities.GetContex().Genre.ToList();
            genres = genres.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = genres.ToList();
        }

        /// <summary>
        ///  Переход на страницу добавления записи
        /// </summary>

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PGenre(null));
        }

        /// <summary>
        ///  Удаление записи
        /// </summary>

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var genreForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Genre>().ToList(); //Выделение полей для удаления 

            if (MessageBox.Show($"Вы точно хотите удалить следущие {genreForRemoving.Count()} Элементов???", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    BusinessLibraryEntities.GetContex().Genre.RemoveRange(genreForRemoving);
                    BusinessLibraryEntities.GetContex().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Genre.ToList();
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
                datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Genre.ToList();
            }
        }

        /// <summary>
        ///  Редактирование записи
        /// </summary>

        private void Btn_bild_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PGenre((sender as Button).DataContext as CourseLibrary.Genre));
        }

        /// <summary>
        /// Экспорт в отчёт Excel
        /// </summary>

        private void btn_excel_Click(object sender, RoutedEventArgs e)
        {
            var allusers = BusinessLibraryEntities.GetContex().Genre.ToList().OrderBy(p => p.Name).ToList();

            var aplication = new Excel.Application();
            aplication.SheetsInNewWorkbook = allusers.Count();

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            int StartRowIndex = 1;

            for (int i = 0; i < allusers.Count(); i++)
            {
                Excel.Worksheet worksheets = aplication.Worksheets.Item[i + 1];
                worksheets.Name = allusers[i].Name;

                worksheets.Cells[1][StartRowIndex] = "Наименование";

                StartRowIndex++;

                foreach (var date in BusinessLibraryEntities.GetContex().Genre)
                {
                    worksheets.Cells[1][StartRowIndex] = date.Name;

                    StartRowIndex++;
                }

                worksheets.Columns.AutoFit();
            }

            aplication.Visible = true;
        }
    }
}
