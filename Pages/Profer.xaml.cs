﻿using CourseLibrary.Class;
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
        public Profer()
        {
            InitializeComponent();
            datagrid.ItemsSource = BusinessLibraryEntities.GetContex().Profer.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string serch = Txtext.Text;
            List<CourseLibrary.Profer> profers = BusinessLibraryEntities.GetContex().Profer.ToList();
            profers = profers.Where(a => a.Name.ToLower().Contains(serch.ToLower())).ToList();
            datagrid.ItemsSource = profers.ToList();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddFrame.frame.Navigate(new AddPages.PProfer());
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
