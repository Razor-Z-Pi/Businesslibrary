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

        public PStudent(Student selectStud)
        {
            InitializeComponent();

            if (selectStud != null)
            {
                _contex = selectStud;
            }

            DataContext = _contex;
            CMDaddress.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
            CMDbook.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var __contex = new Student();
                BusinessLibraryEntities.GetContex().Student.Add(__contex);
                __contex.Name = Name.Text;
                __contex.FName = FName.Text;
                __contex.LName = LName.Text;
                __contex.Pasport_seria = PsP.Text;
                __contex.Telephone = Tel.Text;
                __contex.Address = (Address)CMDaddress.SelectedItem;
                __contex.Book = (Book)CMDbook.SelectedItem;
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
