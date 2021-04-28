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
    /// Логика взаимодействия для Books1.xaml
    /// </summary>
    public partial class Books1 : Page
    {
        public Books1()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Books.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<Book> books = BusinessLibraryEntities.GetContex().Books.ToList();
            books = books.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = books.ToList();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.Pbook());
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
