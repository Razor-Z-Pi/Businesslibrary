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
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Page
    {
        public Avtorization()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Avtorizations.ToList();
        }

        /// <summary>
        ///  Переход на страницу добавления записи
        /// </summary>

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PAvtorization(null));
        }

        /// <summary>
        ///  Удаление записи
        /// </summary>

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Avtorization>().ToList(); //Выделение полей для удаления 

            if (MessageBox.Show($"Вы точно хотите удалить следущие {ForRemoving.Count()} Элементов???", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    BusinessLibraryEntities.GetContex().Avtorizations.RemoveRange(ForRemoving);
                    BusinessLibraryEntities.GetContex().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Avtorizations.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Экспорт в отчёт Excel
        /// </summary>

        private void btn_excel_Click(object sender, RoutedEventArgs e)
        {
            var allusers = BusinessLibraryEntities.GetContex().Avtorizations.ToList().OrderBy(p => p.Login).ToList();

            var aplication = new Excel.Application();
            aplication.SheetsInNewWorkbook = allusers.Count();

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            int StartRowIndex = 1;

            for (int i = 0; i < allusers.Count(); i++)
            {
                Excel.Worksheet worksheets = aplication.Worksheets.Item[i + 1];
                worksheets.Name = allusers[i].Login;

                worksheets.Cells[1][StartRowIndex] = "Имя Автора";

                StartRowIndex++;

                foreach (var date in BusinessLibraryEntities.GetContex().Avtorizations)
                {
                    worksheets.Cells[1][StartRowIndex] = date.Login;

                    StartRowIndex++;
                }

                worksheets.Columns.AutoFit();
            }

            aplication.Visible = true;
        }

        /// <summary>
        ///  Поиск(фильтрация) данных по Имени поля
        /// </summary>

        private void Txtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<CourseLibrary.Avtorization> admin = BusinessLibraryEntities.GetContex().Avtorizations.ToList();
            admin = admin.Where(a => a.Login.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = admin.ToList();
        }

        /// <summary>
        ///  Редактирование записи
        /// </summary>

        private void btn_bild_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PAvtorization((sender as Button).DataContext as CourseLibrary.Avtorization));
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Avtorization>().ToList(); //Выделение полей для удаления 
            BusinessLibraryEntities.GetContex().Avtorizations.RemoveRange(ForRemoving);
            BusinessLibraryEntities.GetContex().SaveChanges();
        }

        /// <summary>
        ///  Обновление данных на странице при добавление, удаление, редактирование!!!
        /// </summary>

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusinessLibraryEntities.GetContex().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Avtorizations.ToList();
            }
        }
    }
}
