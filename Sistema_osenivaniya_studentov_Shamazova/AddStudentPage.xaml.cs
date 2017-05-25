using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        public AddStudentPage(Teacher id)
        {
            P = id;
            InitializeComponent();
            label.Content = "Оценка по предмету '" + id.Subject + "'";
            subject = id.Subject;
            FIO.Focus();
            FIO.TabIndex = 0;
            Group.TabIndex = 1;
            Mark.TabIndex = 2;
            Login.TabIndex = 3;
            Password.TabIndex = 4;
        }
        Teacher P;
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
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
                var hash = CalculateHash(Password.Text);
                Authorization Leysan = new Authorization(Login.Text, hash, s);
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
                Object stud = new Students("-1", "-1", "-1", "-1", "-1", -1);
                Authorization aut = new Authorization("-1", "-1", stud);
                HistoryOfChanges hist = new HistoryOfChanges(aut,Leysan);
                P.History.Add(hist);
                P.MakeIt10();
                foreach (Authorization X in list)
                {
                    try
                    {
                        Teacher t = (Teacher)X.User;
                        if (P.Name == t.Name && P.Sername == t.Sername && P.Subject == t.Subject && P.Patronymic == t.Patronymic)
                        {

                            t.History = P.History;
                        }
                    }
                    catch { }
                }
                ser.Serialize(list);
                MessageBox.Show("Студент добавлен", "-", MessageBoxButton.OK);
                
                FIO.Text = "";
                FIO.Focus();
                Group.Text = "";
                Mark.Text = "";
                Login.Text = "";
                Password.Text = "";
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            LABEL.FontSize = 10;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            LABEL.FontSize = 8;
        }

        private void Add_MouseEnter(object sender, MouseEventArgs e)
        {
            Add.Background = new SolidColorBrush(Colors.HotPink);
        }

        private void Add_MouseLeave(object sender, MouseEventArgs e)
        {
            Add.Background = new SolidColorBrush(Colors.LavenderBlush);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
