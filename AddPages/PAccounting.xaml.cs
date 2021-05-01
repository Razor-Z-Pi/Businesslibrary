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
    /// Логика взаимодействия для PAccounting.xaml
    /// </summary>
    public partial class PAccounting : Page
    {
        Accounting __contex = new Accounting();

        public PAccounting(Accounting selectedAccounting)
        {
            InitializeComponent();

            if (selectedAccounting != null)
            {
                __contex = selectedAccounting;
            }

            cmb_profer.ItemsSource = BusinessLibraryEntities.GetContex().Profer.ToList();
            cmb_stud.ItemsSource = BusinessLibraryEntities.GetContex().Student.ToList();
            cmb_book.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();

            DataContext = __contex;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var _contex = new Accounting();
                BusinessLibraryEntities.GetContex().Accounting.Add(_contex);
                _contex.Profer = (Profer)cmb_profer.SelectedItem;
                _contex.Student = (Student)cmb_stud.SelectedItem;
                _contex.Book = (Book)cmb_book.SelectedItem;
                _contex.NumberOfBooks = Numberbook.Text;
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
