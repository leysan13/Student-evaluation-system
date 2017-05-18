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
    /// Логика взаимодействия для DeleteStudent.xaml
    /// </summary>
    public partial class DeleteStudent : Window
    {
            void W_Closing(object sender, CancelEventArgs e)
            {
                Owner.Show();
            }
            public DeleteStudent()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if ((FIO.Text == "") || (Group.Text == ""))
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Authorization> list;
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
                using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
                {

                    try
                    {
                        list = (List<Authorization>)formatter.Deserialize(fs);
                    }
                    catch
                    {
                        MessageBox.Show("Студент не найден", "-", MessageBoxButton.OK);
                        return;
                    }
                }
                bool t = false;
                foreach (Authorization student in list)
                {
                    try
                    {
                        Students st = (Students)student.User;
                        if ((mas[0] == st.Sername) && (mas[1] == st.Name) && (mas[2] == st.Patronymic) && (Group.Text == st.Group))
                        {
                            list.Remove(student);
                            MessageBox.Show("Удаление завершено", "-", MessageBoxButton.OK);
                            FIO.Text = "";
                            Group.Text = "";
                            t = true;
                            break;
                        }
                    }
                    catch { }

                }
                if (t == false)
                { MessageBox.Show("Студент не найден", "-", MessageBoxButton.OK); }
                using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
                {
                    formatter.Serialize(fs, list);
                }
            }
        }
    }
}
