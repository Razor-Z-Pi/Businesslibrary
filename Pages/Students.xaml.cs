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
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Students.ToList();
        }

        private void Txtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<Student> stud = BusinessLibraryEntities.GetContex().Students.ToList();
            stud = stud.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = stud.ToList();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PStudent());
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
