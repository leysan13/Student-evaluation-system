using System;
using System.Collections;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Registration : Window
    {
        void W_Closing(object sender, CancelEventArgs e)
        {
            Owner.Show();
        }

        public Registration()
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
                        MessageBox.Show("Введённый логин уже используется", "", MessageBoxButton.OK);
                        return;
                    }
                }

                list.Add(new Authorization(Login.Text, Password.Text, new Teacher(Sername.Text, Name.Text, Patronymic.Text, Subject.Text)));
                using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
                {
                    formatter.Serialize(fs, list);
                }
                MessageBox.Show("Регистрация прошла успешно!", "", MessageBoxButton.OK);
                Close();

            }
        }
            
        


        }

    }
