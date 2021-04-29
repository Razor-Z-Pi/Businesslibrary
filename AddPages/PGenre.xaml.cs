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
    /// Логика взаимодействия для PGenre.xaml
    /// </summary>
    public partial class PGenre : Page
    {

        private Genre _contex = new Genre();

        public PGenre(Genre selectedGenre)
        {
            InitializeComponent();

            if (selectedGenre != null)
            {
                _contex = selectedGenre;
            }

            DataContext = _contex;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_contex.Name))
            {
                errors.AppendLine("Укажите название жанра");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_contex.id_Genre == 0)
            {
                BusinessLibraryEntities.GetContex().Genre.Add(_contex);
            }

            try
            {
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
