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
    /// Логика взаимодействия для Address.xaml
    /// </summary>
    public partial class Address : Page
    {
        public Address()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
        }

        /// <summary>
        ///  Поиск(фильтрация) данных по Имени поля
        /// </summary>

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<CourseLibrary.Address> addresses = BusinessLibraryEntities.GetContex().Address.ToList();
            addresses = addresses.Where(a => a.Strets.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = addresses.ToList();
        }

        /// <summary>
        ///  Переход на страницу добавления записи
        /// </summary>

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PAddress(null));
        }

        /// <summary>
        ///  Удаление записи
        /// </summary>

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Address>().ToList(); //Выделение полей для удаления 

            if (MessageBox.Show($"Вы точно хотите удалить следущие {ForRemoving.Count()} Элементов???", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    BusinessLibraryEntities.GetContex().Address.RemoveRange(ForRemoving);
                    BusinessLibraryEntities.GetContex().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
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
                datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
            }
        }

        /// <summary>
        ///  Редактирование записи
        /// </summary>

        private void Btn_bild_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PAddress((sender as Button).DataContext as CourseLibrary.Address));
        }

        /// <summary>
        /// Экспорт в отчёт Excel
        /// </summary>

        private void btn_excel_Click(object sender, RoutedEventArgs e)
        {
            var allusers = BusinessLibraryEntities.GetContex().Address.ToList().OrderBy(p => p.Strets).ToList();

            var aplication = new Excel.Application();
            aplication.SheetsInNewWorkbook = allusers.Count();

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            int StartRowIndex = 1;

            for (int i = 0; i < allusers.Count(); i++)
            {
                Excel.Worksheet worksheets = aplication.Worksheets.Item[i + 1];
                worksheets.Name = allusers[i].Strets;

                worksheets.Cells[1][StartRowIndex] = "Улица";
                worksheets.Cells[2][StartRowIndex] = "Дом";
  

                StartRowIndex++;

                foreach (var date in BusinessLibraryEntities.GetContex().Address)
                {
                    worksheets.Cells[1][StartRowIndex] = date.Strets;
                    worksheets.Cells[2][StartRowIndex] = date.Home;

                    StartRowIndex++;
                }

                worksheets.Columns.AutoFit();
            }

            aplication.Visible = true;
        }
    }
}
