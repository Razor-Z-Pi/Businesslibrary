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
using System.ComponentModel;
using System.IO;

namespace CourseLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string patch = @"Login.txt"; // Путь для файла с записью логина
        string patch1 = @"Password.txt"; // Путь для файла с записью к паролю
        string number = @"num.txt"; // Путь для файла с записью для Активации запоминания данных в полях

        int num = 0; // Переменная для счётчика движения, при не правильном входе в приложение
        int on = 0; // Переменная которая в дальнейшем будет влиять на запоминания
        BusinessLibraryEntities contex; // Обьявление БД
        static StreamWriter sw; // Поток для записи в файл
        static StreamReader sr; // Поток для чтения из файла

        public MainWindow()
        {
            InitializeComponent();
            contex = new BusinessLibraryEntities(); // Подключённая БД
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Name = Login.Text; // Текст введёный пользователем в поле логина
            string password;  // Переменная для пароля введённым пользователем
            password = Password_1.Password;

            if (Password_ninjza.IsChecked == true)  // Если выбрана галочка для показывание пароля, то в переменную password ложится текст из поля для пароля и наоборот, так как всё реализовано с помошью двух обьектов
            {
                password = Password.Text;
            }
            else
            {
                password = Password_1.Password;     
            }

            Password.Text = password; // Для шифрования

            if ( (Login.Text != "") || (Password.Text != "") ) // Проверка на пустату полей Логина и Пароля
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

                try // Для не предвиденных событий
                {
                    var userObj = contex.Avtorizations.FirstOrDefault(x => x.Login == Login.Text && x.Password == Password.Text); // Проверка и сопастовления введёных данных пользователя с существующеми данными в БД
                    var profer = contex.Profers.FirstOrDefault(); // Для вытягивания данных о руководителях

                    if (userObj == null) // Если пользователь ввёл не правильно данные
                    {
                        MessageBox.Show("Такого пользователя нет",
                                        "Ошибка Авторизации",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                        num += 1; // Счётчик для 5 неправельных вводов
                        if (num == 5) // В этом блоке отключаем кнопку и задерживаем время на 10сек, до аовторных попыток
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
                            user = profer.Name + " " + profer.FName + " " + profer.LName; // Создали ранее переменную в которую сложим ФИО Руково-лей
                        }

                        MessageBox.Show("Рады вас видить " + $"{user}", // Вобщем это для декора, и какой сотрудник зашёл в приложение
                                        "Добро пожаловать");
                        this.Hide(); // Вскрываем главное Окно MainWindow
                        WorkGo workgo = new WorkGo(); // Создали обьект экземпляра для второго Окна
                        workgo.Show(); // Показываем при успешной попытки
                        this.Close(); // Закрываем главное окно MainWindow

                        if (Load_date.IsChecked == true) // Если галочка стоит на запомнить меня 
                        {
                            on = 1; // Как раз помещаем в переменную для активации заполнения полей

                            string Logint = Login.Text;
                            string passwordL = Password.Text;
                            string PasswordPas = Password_1.Password;

                            if (passwordL == "") // Если пустое поле textbox пароля, заполненяется с Password так как эот поле каторе в начеле видно!!! 
                            {
                                passwordL = PasswordPas;
                            }

                            DirectoryInfo directoryInfo = new DirectoryInfo(patch); // Организация директория путя к файлу Логина
                            DirectoryInfo directoryInfo2 = new DirectoryInfo(patch1); // Организация директория путя к файлу Пароля
                            DirectoryInfo info = new DirectoryInfo(number); // Организация директория путя к файлу активацию

                            try // Способ обхода не предвиденных действий
                            {
                                if (!directoryInfo.Exists) // Если файл существует
                                {
                                    sw = new StreamWriter(patch);
                                    sw.Write(Logint);
                                    sw.Close();
                                }
                                if (!directoryInfo2.Exists) // Если файл существует
                                {
                                    sw = new StreamWriter(patch1);
                                    sw.Write(passwordL);
                                    sw.Close();
                                }
                                if (!info.Exists) // Если файл существует
                                {
                                    sw = new StreamWriter(number);
                                    sw.Write(on);
                                    sw.Close();
                                }


                            }
                            catch (Exception ex) // Показывает об не предведенных ошибках
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else // Если снял галочку, с запоминания!!!
                        { 
                            on = 0; // Чтобы не ативировать запоминания данных входа
                            sw = new StreamWriter(number); // Для записи чтобы не было багов, так как в файле 1, и если мы не работает 
                            sw.Write(on);
                            sw.Close();
                        }
                    }
                }
                catch (Exception ex) // Показывает об не предведенных ошибках
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
                Password.Text = Password_1.Password; // Скопируем в TextBox из PasswordBox
                Password.Visibility = Visibility.Visible; // TextBox - отобразить
                Password_1.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                Password_1.Password = Password.Text; // Скопируем в PasswordBox из TextBox 
                Password.Visibility = Visibility.Hidden; // TextBox - скрыть
                Password_1.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sr = new StreamReader(number); // Чтения из файла для активация 
            string zet = sr.ReadLine(); // Вкладываем данные в переменную
            sr.Close(); // Закрывания файла
            on = Convert.ToInt32(zet); // Конвертирования в целочисленное для сравнения 
            if (on == 1) // Сравневаем число, если они совпадают то, активация срабатывает и заполняем данные
            { 
                sr = new StreamReader(patch); // Чтения из файла логина
                string text1 = sr.ReadLine(); // Переменная для данных
                sr.Close(); 
                Login.Text = text1; // Заполняем поля в интерфейсе 
                sr = new StreamReader(patch1); //  Чтения из файла пароля
                string text2 = sr.ReadLine(); 
                sr.Close();
                Password_1.Password = text2;  
                Load_date.IsChecked = true; // Включения ChekBox, для запоминания данных
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
    }
}
