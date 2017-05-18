using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Shapes;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        void W_Closing(object sender, CancelEventArgs e) {
            Owner.Show();
        }

        public AddStudent(TeachersWindow w)
        {
            Owner = w;
            InitializeComponent();
            label.Content = "Оценка по предмету '" + w.P.Subject + "'";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if ((FIO.Text == "") || (Group.Text == "") || (Mark.Text == "") || (Login.Text == "") || (Password.Text == ""))
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                string[] mas = FIO.Text.Split(new char[] { ' ' });
                if (mas.Length <3)
                {
                    MessageBox.Show("Заполните поле 'ФИО' должным образом.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (mas.Length > 3)
                {
                    MessageBox.Show("Заполните поле 'ФИО' должным образом. \nСлишком много данных в одной строке.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                Students s = new Students(mas[0], mas[1], mas[2], Group.Text, ((TeachersWindow)Owner).P.Subject, int.Parse(Mark.Text));    
                BinaryFormatter formatter = new BinaryFormatter();
                List<Authorization> list;

                using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
                {
                    try
                    {
                        list = (List<Authorization>)formatter.Deserialize(fs);
                    }
                    catch
                    {
                        list = new List<Authorization>();
                    }
                }
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

                using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
                {
                    formatter.Serialize(fs, list);
                }
                MessageBox.Show("Студент добавлен", "-", MessageBoxButton.OK);
                FIO.Text = "";
                Group.Text = "";
                Mark.Text = "";
                Login.Text = "";
                Password.Text = "";
            }
        }
    }
}
