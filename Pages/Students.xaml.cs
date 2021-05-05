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
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        public Students()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Student.ToList();
        }

        /// <summary>
        ///  Поиск(фильтрация) данных по Имени поля
        /// </summary>

        private void Txtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<Student> stud = BusinessLibraryEntities.GetContex().Student.ToList();
            stud = stud.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = stud.ToList();
        }

        /// <summary>
        ///  Переход на страницу добавления записи
        /// </summary>

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PStudent(null));
        }

        /// <summary>
        ///  Удаление записи
        /// </summary>

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Student>().ToList(); //Выделение полей для удаления 

            if (MessageBox.Show($"Вы точно хотите удалить следущие {ForRemoving.Count()} Элементов???", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    BusinessLibraryEntities.GetContex().Student.RemoveRange(ForRemoving);
                    BusinessLibraryEntities.GetContex().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Student.ToList();
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
                datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Student.ToList();
            }
        }

        /// <summary>
        ///  Редактирование записи
        /// </summary>

        private void btn_bild_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PStudent((sender as Button).DataContext as CourseLibrary.Student));
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Student>().ToList(); //Выделение полей для удаления 
            BusinessLibraryEntities.GetContex().Student.RemoveRange(ForRemoving);
            BusinessLibraryEntities.GetContex().SaveChanges();
        }

        /// <summary>
        /// Экспорт в отчёт Excel
        /// </summary>

        private void btn_excel_Click(object sender, RoutedEventArgs e)
        {
            var allusers = BusinessLibraryEntities.GetContex().Student.ToList().OrderBy(p => p.FName).ToList();

            var aplication = new Excel.Application();
            aplication.SheetsInNewWorkbook = allusers.Count();

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            int StartRowIndex = 1;

            for (int i = 0; i < allusers.Count(); i++)
            {
                Excel.Worksheet worksheets = aplication.Worksheets.Item[i + 1];
                worksheets.Name = allusers[i].FName;

                worksheets.Cells[1][StartRowIndex] = "Имя";
                worksheets.Cells[2][StartRowIndex] = "Фамилия";
                worksheets.Cells[3][StartRowIndex] = "Очество";
                worksheets.Cells[4][StartRowIndex] = "Серия паспорта";
                worksheets.Cells[5][StartRowIndex] = "Телефон";
                worksheets.Cells[6][StartRowIndex] = "Адрес";
                worksheets.Cells[7][StartRowIndex] = "Книга";

                StartRowIndex++;

                foreach (var date in BusinessLibraryEntities.GetContex().Student)
                {
                    worksheets.Cells[1][StartRowIndex] = date.Name;
                    worksheets.Cells[2][StartRowIndex] = date.FName;
                    worksheets.Cells[3][StartRowIndex] = date.LName;
                    worksheets.Cells[4][StartRowIndex] = date.Pasport_seria;
                    worksheets.Cells[5][StartRowIndex] = date.Telephone;
                    worksheets.Cells[6][StartRowIndex] = date.Address.Strets;
                    worksheets.Cells[7][StartRowIndex] = date.Book.Name;

                    StartRowIndex++;
                }

                worksheets.Columns.AutoFit();
            }

            aplication.Visible = true;
        }
    }
}
