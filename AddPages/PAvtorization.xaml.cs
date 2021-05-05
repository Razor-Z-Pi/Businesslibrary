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
    /// Логика взаимодействия для PAvtorization.xaml
    /// </summary>
    public partial class PAvtorization : Page
    {
        Avtorization __contex = new Avtorization();
        
        /// <summary>
        ///  Обьявления экземпляра нужной таблицы из БД, для манипуляциями самих данных
        /// </summary>

        public PAvtorization(Avtorization selectedAvtoriz)
        {
            InitializeComponent();

            if (selectedAvtoriz != null)
            {
                selectedAvtoriz = __contex;
            }

            this.DataContext = selectedAvtoriz;

            cmb_profer.ItemsSource = BusinessLibraryEntities.GetContex().Profer.ToList();

            DataContext = __contex;
        }

        /// <summary>
        /// Добавления данных в определённую таблицу БД, ведённых пользователем!!!
        /// </summary>

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var _contex = new Avtorization();
                BusinessLibraryEntities.GetContex().Avtorizations.Add(_contex);
                _contex.Login = login.Text;
                _contex.Password = password.Text;
                _contex.Profer = (Profer)cmb_profer.SelectedItem;
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
