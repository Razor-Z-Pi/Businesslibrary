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
using System.Windows.Shapes;

namespace CourseLibrary
{
    /// <summary>
    /// Логика взаимодействия для Otchot.xaml
    /// </summary>
    public partial class Otchot : Window
    {
        public Otchot()
        {
            InitializeComponent();
            AddFrame.frame = frmPrinter;
            frmPrinter.Navigate(new PagesOtcoth.accountOtch());
        }

        private void student_Click(object sender, RoutedEventArgs e)
        {
            frmPrinter.Navigate(new PagesOtcoth.stdOtch());
        }

        private void books_Click(object sender, RoutedEventArgs e)
        {
            frmPrinter.Navigate(new PagesOtcoth.bookOtch());
        }

        private void accounting_Click(object sender, RoutedEventArgs e)
        {
            frmPrinter.Navigate(new PagesOtcoth.accountOtch());
        }

        private void Printer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(this.Printers, "Отчёт");
            }          
        }
    }
}
