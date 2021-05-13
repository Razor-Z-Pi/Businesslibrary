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
    /// Логика взаимодействия для PProfer.xaml
    /// </summary>
    public partial class PProfer : Page
    {

        private Profer _contex = new Profer();

        /// <summary>
        ///  Обьявления экземпляра нужной таблицы из БД, для манипуляциями самих данных
        /// </summary>

        public PProfer(Profer selectedProfer)
        {
            InitializeComponent();

            if (selectedProfer != null)
            {
                _contex = selectedProfer;
            }

            DataContext = _contex;
        }

        /// <summary>
        /// Добавления данных в определённую таблицу БД, ведённых пользователем!!!
        /// </summary>

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_contex.Name))
            {
                errors.AppendLine("Укажите Имя");
            }

            if (string.IsNullOrWhiteSpace(_contex.FName))
            {
                errors.AppendLine("Укажите Фамилия");
            }

            if (string.IsNullOrWhiteSpace(_contex.LName))
            {
                errors.AppendLine("Укажите Отчество");
            }

            if (string.IsNullOrWhiteSpace(_contex.Specialty))
            {
                errors.AppendLine("Укажите название Специальности");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_contex.id_Profer == 0)
            {
                BusinessLibraryEntities.GetContex().Profer.Add(_contex);
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
