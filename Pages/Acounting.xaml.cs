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
    /// Логика взаимодействия для Acounting.xaml
    /// </summary>
    public partial class Acounting : Page
    {
        public Acounting()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Accounting.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<CourseLibrary.Profer> pro = BusinessLibraryEntities.GetContex().Profer.ToList();
            pro = pro.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = pro.ToList();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PAccounting(null));
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = datagrid.SelectedItems.Cast<CourseLibrary.Accounting>().ToList(); //Выделение полей для удаления 

            if (MessageBox.Show($"Вы точно хотите удалить следущие {ForRemoving.Count()} Элементов???", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    BusinessLibraryEntities.GetContex().Accounting.RemoveRange(ForRemoving);
                    BusinessLibraryEntities.GetContex().SaveChanges();
                    MessageBox.Show("Данные удалены!!!");

                    datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Accounting.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusinessLibraryEntities.GetContex().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Accounting.ToList();
            }
        }

        private void btn_bild_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PAccounting((sender as Button).DataContext as CourseLibrary.Accounting));
        }
    }
}
