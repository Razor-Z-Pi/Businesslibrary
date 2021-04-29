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
    /// Логика взаимодействия для PAvtor.xaml
    /// </summary>
    public partial class PAvtor : Page
    {
        private Avtor _contex = new Avtor();

        public PAvtor(Avtor selectedAvtor)
        {
            InitializeComponent();

            if (selectedAvtor != null)
            {
                _contex = selectedAvtor;
            }

            DataContext = _contex;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_contex.Name))
            {
                errors.AppendLine("Укажите ФИО Автора");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_contex.id_Avtor == 0)
            {
                BusinessLibraryEntities.GetContex().Avtor.Add(_contex);
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
