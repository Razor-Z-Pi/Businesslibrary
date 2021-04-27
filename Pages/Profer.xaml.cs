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
    /// Логика взаимодействия для Profer.xaml
    /// </summary>
    public partial class Profer : Page
    {
        BusinessLibraryEntities contex; // Обьявление БД
        public Profer()
        {
            InitializeComponent();
            contex = new BusinessLibraryEntities();
            datagrid.ItemsSource = contex.Profer.ToList();
        }
    }
}
