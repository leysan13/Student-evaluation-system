using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
               
                Prepodavatel d = null;
                string[] line = File.ReadAllLines("../../BazaD_Prepod.txt");
                for (int i = 0; i < line.Length; i++)
                {

                    string[] mas = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    d = new Prepodavatel(mas[0], mas[1], mas[2], mas[3], mas[4], mas[5]);
                    if (mas[4] == textBox4.Text)
                    {
                        arj.Add(d);
                        MessageBox.Show("Введённый логин уже используется", "", MessageBoxButton.OK);
                    }

                }
                if (arj.Count==0)
                    {
                        Prepodavatel pr;
                        pr = new Prepodavatel(Fam_Textbox.Text, textBox2.Text, textBox3.Text, Choose.Text, textBox4.Text, textBox5.Text);
                        arj.Add(pr);
                        using (StreamWriter sw = new StreamWriter("../../BazaD_Prepod.txt", true))
                            {
                            foreach (Prepodavatel p in arj)
                                sw.WriteLine("{0} {1} {2} {3} {4} {5}", pr.Sername, pr.Name, pr.Patronymic, pr.Predmet, pr.Login, pr.Parol);

                    }
                    MessageBox.Show("Регистрация прошла успешно!", "", MessageBoxButton.OK);
                    Close();
                }
                arj.Clear();

            }
        }
            
        


        }

    }
