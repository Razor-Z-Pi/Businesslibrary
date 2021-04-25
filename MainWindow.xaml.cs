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
using System.Data.SqlClient;
using System.Threading;

namespace CourseLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0; // Переменная для счётчика движения, при не правильном входе в приложение
        BusinessLibraryEntities contex; // Обьявление БД

        public MainWindow()
        {
            InitializeComponent();
            contex = new BusinessLibraryEntities(); // Подключённая БД
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Name = Login.Text; // Текст введёный пользователем в поле логина
            string password;  // Переменная для пароля введённым пользователем

            if (Password_ninjza.IsChecked == true)  //Если выбрана галочка для показывание пароля, то в переменную password ложится текст из поля для пароля и наоборот, так как всё реализовано с помошью двух обьектов
            {
                password = Password.Text;
            }
            else
            {
                password = Password_1.Password;
            }
            

            if ((Login.Text != "") || (Password.Text != "")) // Проверка на пустату полей Логина и Пароля
            {
                if (Login.Text == "")
                {
                    MessageBox.Show("Заполните поле логина",
                                    "Внимание",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }
                if (Password.Text == "")
                {
                    MessageBox.Show("Заполните поле пароля",
                                    "Внимание",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                }

                try //Для не предвиденных событий
                {
                    var userObj = contex.Avtorizations.FirstOrDefault(x => x.Login == Login.Text && x.Password == Password.Text); // Проверка и сопастовления введёных данных пользователя с существующеми данными в БД
                    var profer = contex.Profers.FirstOrDefault(); // Для вытягивания данных о руководителях

                    if (userObj == null) // Если пользователь ввёл не правильно данные
                    {
                        MessageBox.Show("Такого пользователя нет",
                                        "Ошибка Авторизации",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                        num += 1; //счётчик для 5 неправельных вводов
                        if (num == 5) //В этом блоке отключаем кнопку и задерживаем время на 10сек, до аовторных попыток
                        {
                            btnOpen.IsEnabled = false;
                            MessageBox.Show("Вы использовали пять попыток входа подождите 10 секунд, и попробуйте ещё раз",
                                        "Внимание",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                            num = 0;
                            Thread.Sleep(10000);
                            btnOpen.IsEnabled = true;
                            
                        }
                    }
                    else
                    {
                        var user = "";
                        if (userObj.id_Profer == profer.id_Profer) // Сравниваем в БД Данные Руководителей
                        {
                            user = profer.Name + " " + profer.FName + " " + profer.LName; //Создали ранее переменную в которую сложим ФИО Руково-лей
                        }

                        MessageBox.Show("Рады вас видить " + $"{user}", // Вобщем это для декора, и какой сотрудник зашёл в приложение
                                        "Добро пожаловать");
                        this.Hide(); //Вскрываем главное Окно MainWindow
                        WorkGo workgo = new WorkGo(); // Создали обьект экземпляра для второго Окна
                        workgo.Show(); //Показываем при успешной попытки
                        this.Close(); //Закрываем главное окно MainWindow
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка " + ex.Message.ToString(),
                    "Критичиская работа приложения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля авторизации",
                "Внимание",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }

        private void Password_ninjza_Click(object sender, RoutedEventArgs e) // При нажатие на голочку с показом пароля будут мнятся обьекты между собой
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                Password.Text = Password_1.Password; // скопируем в TextBox из PasswordBox
                Password.Visibility = Visibility.Visible; // TextBox - отобразить
                Password_1.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                Password_1.Password = Password.Text; // скопируем в PasswordBox из TextBox 
                Password.Visibility = Visibility.Hidden; // TextBox - скрыть
                Password_1.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }
    }
}
