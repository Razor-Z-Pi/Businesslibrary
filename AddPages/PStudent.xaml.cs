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
        public PStudent()
        {
            InitializeComponent();
            cmb_adr.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
            cmb_book.ItemsSource = BusinessLibraryEntities.GetContex().Address.ToList();
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
