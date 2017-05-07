using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class Window1 : Window
    {


        public Window1()
        {
            InitializeComponent();
        }
        ArrayList arj = new ArrayList();

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            if ((Fam_Textbox.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (Choose.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK);

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
                    if (x.Login == textBox4.Text)
                    {
                        MessageBox.Show("Введённый логин уже используется", "", MessageBoxButton.OK);
                        return;
                    }
                }

                list.Add(new Authorization(textBox4.Text, textBox5.Text, new Prepodavatel(Fam_Textbox.Text, textBox2.Text, textBox3.Text, Choose.Text)));
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
