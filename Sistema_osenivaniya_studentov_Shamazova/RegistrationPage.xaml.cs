using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
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

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Sername.Focus();
            
        }
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        ArrayList arj = new ArrayList();
        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            if ((Sername.Text == "") || (Name.Text == "") || (Patronymic.Text == "") || (Subject.Text == "") || (Login.Text == "") || (Password.Text == ""))
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

            else
            {
                if ((Sername.Text == "") || (Name.Text == "") || (Patronymic.Text == "") || (Subject.Text == "") || (Login.Text == "") || (Password.Text == ""))
                {
                    MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                else
                {
                    Serialization ser = new Serialization();
                    List<Authorization> list = ser.Deserialize();
                    foreach (Authorization x in list)
                    {
                        if (x.Login == Login.Text)
                        {
                            MessageBox.Show("Введённый логин уже используется", "", MessageBoxButton.OK);
                            return;
                        }
                    }
                    var hash = CalculateHash(Password.Text);
                    Teacher t = new Teacher(Sername.Text, Name.Text, Patronymic.Text, Subject.Text);
                    Students s = new Students("-1", "-1", "-1", "-1", t.Subject, -1);
                    t.History = new List<HistoryOfChanges>();
                    Authorization aut = new Authorization("-1", "-1", s);
                    HistoryOfChanges hist = new HistoryOfChanges(aut, aut);
                    t.History.Add(hist);
                    Authorization a = new Authorization(Login.Text, hash,t);
                    list.Add(a);
                    ser.Serialize(list);
                    MessageBox.Show("Регистрация прошла успешно!", "", MessageBoxButton.OK);

                }

            }
            Name.Text = "";
            Sername.Text = "";
            Patronymic.Text = "";
            Subject.Text = "";
            Login.Text = "";
            Password.Text = "";
            NavigationService.GoBack();

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
