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

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        public AddStudentPage(Teacher id)
        {
            InitializeComponent();
            label.Content = "Оценка по предмету '" + id.Subject + "'";
            subject = id.Subject;
        }
        string subject;
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if ((FIO.Text == "") || (Group.Text == "") || (Mark.Text == "") || (Login.Text == "") || (Password.Text == ""))
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                string[] mas = FIO.Text.Split(new char[] { ' ' });
                if (mas.Length < 3)
                {
                    MessageBox.Show("Заполните поле 'ФИО' должным образом.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (mas.Length > 3)
                {
                    MessageBox.Show("Заполните поле 'ФИО' должным образом. \nСлишком много данных в одной строке.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                Serialization ser = new Serialization();
                Students s = new Students(mas[0], mas[1], mas[2], Group.Text, subject, int.Parse(Mark.Text));
                List<Authorization> list = ser.Deserialize();
                foreach (Authorization x in list)
                {
                    if (x.Login == Login.Text)
                    {
                        MessageBox.Show("Введённый логин уже используется", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }
                }
                Authorization Leysan = new Authorization(Login.Text, Password.Text, s);
                list.Add(Leysan);
                List<string> sername = new List<string>();
                Authorization a;
                for (int i = 0; i < list.Count; i++)
                {
                    try
                    {
                        Students st = (Students)list[i].User;
                        sername.Add(st.Sername);
                    }
                    catch { }
                }
                sername.Sort();
                for (int i = 0; i < sername.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        try
                        {
                            Students st = (Students)list[j].User;
                            if (st.Sername == sername[i])
                            {
                                a = list[j];
                                list[j] = list[i];
                                list[i] = a;
                            }
                        }
                        catch { }
                    }
                }
                ser.Serialize(list);
                MessageBox.Show("Студент добавлен", "-", MessageBoxButton.OK);
                FIO.Text = "";
                Group.Text = "";
                Mark.Text = "";
                Login.Text = "";
                Password.Text = "";
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            label.FontSize = 10;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            label.FontSize = 8;
        }

        private void Add_MouseEnter(object sender, MouseEventArgs e)
        {
            Add.Background = new SolidColorBrush(Colors.HotPink);
        }

        private void Add_MouseLeave(object sender, MouseEventArgs e)
        {
            Add.Background = new SolidColorBrush(Colors.LavenderBlush);
        }
    }
}
