using CourseLibrary.Class;
using CourseLibrary.Pages;
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
    /// Логика взаимодействия для WorkGo.xaml
    /// </summary>
    public partial class WorkGo : Window
    {
        public WorkGo()
        {
            InitializeComponent();
            AddFrame.frame = frm;
        }

        private void Btn_book_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Books1());
        }

        private void Btn_avtor_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Pages.Avtor());
        }

        private void Btn_genre_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Pages.Genre());
        }

        private void Btn_student_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Students());
        }

        private void Btn_address_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Pages.Address());
        }

        private void Btn_acountin_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Acounting());
        }

        private void Btn_profer_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new Pages.Profer());
        }

        private void Developer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Попов Павел",
                            "Внимание",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
        }

        private void next1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ru.bookmate.com/");
        }

        private void next2_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gutenberg.org/");
        }

        private void next3_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://imwerden.de/");
        }

        private void next4_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.elibrary.ru/defaultx.asp?");
        }
    }
}
