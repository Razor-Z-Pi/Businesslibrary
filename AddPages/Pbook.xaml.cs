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
    /// Логика взаимодействия для Pbook.xaml
    /// </summary>
    public partial class Pbook : Page
    {

        Book __contex = new Book();

        /// <summary>
        ///  Обьявления экземпляра нужной таблицы из БД, для манипуляциями самих данных
        /// </summary>

        public Pbook(Book selectedBook)
        {
            InitializeComponent();

            if (selectedBook != null)
            {
                selectedBook = __contex;
            }

            this.DataContext = selectedBook;

            cmb_genre.ItemsSource = BusinessLibraryEntities.GetContex().Genre.ToList();
            cmb_avtor.ItemsSource = BusinessLibraryEntities.GetContex().Avtor.ToList();

            DataContext = __contex;
        }

        /// <summary>
        /// Добавления данных в определённую таблицу БД, ведённых пользователем!!!
        /// </summary>

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var _contex = new Book();
                BusinessLibraryEntities.GetContex().Books.Add(_contex);
                _contex.Name = NameB.Text;
                _contex.Genre = (Genre)cmb_genre.SelectedItem;
                _contex.Avtor = (Avtor)cmb_avtor.SelectedItem;
                _contex.NumberOfLines = numberoflines.Text;
                _contex.Amount = amount.Text;
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
