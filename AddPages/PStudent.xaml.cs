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

namespace CourseLibrary.AddPages
{
    /// <summary>
    /// Логика взаимодействия для PStudent.xaml
    /// </summary>
    public partial class PStudent : Page
    {
        private Student _contex = new Student();

        public PStudent()
        {
            InitializeComponent();

            DataContext = _contex;
            CMDaddress.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
            CMDbook.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_contex.Name))
            {
                errors.AppendLine("Укажите Имя");
            }

            if (string.IsNullOrWhiteSpace(_contex.FName))
            {
                errors.AppendLine("Укажите Фамилию");
            }

            if (string.IsNullOrWhiteSpace(_contex.LName))
            {
                errors.AppendLine("Укажите Отчество");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_contex.id_Student == 0)
            {
                BusinessLibraryEntities.GetContex().Student.Add(_contex);
            }

            try
            {
                var newStudent = new Student();
                newStudent.id_Address = Convert.ToInt32((Address)CMDaddress.SelectedItem);
                newStudent.id_Book = Convert.ToInt32((Book)CMDbook.SelectedItem);
                BusinessLibraryEntities.GetContex().SaveChanges();
                MessageBox.Show("Информацию сохранена!!!");
                AddFrame.frame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
