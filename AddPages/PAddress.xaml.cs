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
    /// Логика взаимодействия для PAddress.xaml
    /// </summary>
    public partial class PAddress : Page
    {
        private Address _contex = new Address();

        /// <summary>
        ///  Обьявления экземпляра нужной таблицы из БД, для манипуляциями самих данных
        /// </summary>

        public PAddress(Address selectedAddress)
        {
            InitializeComponent();

            if (selectedAddress != null)
            {
                _contex = selectedAddress;
            }
            
            DataContext = _contex;
        }

        /// <summary>
        /// Добавления данных в определённую таблицу БД, ведённых пользователем!!!
        /// </summary>

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_contex.Strets))
            {
                errors.AppendLine("Укажите название улицы");
            }

            if (string.IsNullOrWhiteSpace(_contex.Home))
            {
                errors.AppendLine("Укажите название дома");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_contex.id_Address == 0)
            {
                BusinessLibraryEntities.GetContex().Address.Add(_contex);
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
