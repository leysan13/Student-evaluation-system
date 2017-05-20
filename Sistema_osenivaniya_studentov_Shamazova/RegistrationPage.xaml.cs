using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                    list.Add(new Authorization(Login.Text, Password.Text, new Teacher(Sername.Text, Name.Text, Patronymic.Text, Subject.Text)));
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
    }
}
