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
        MainWindow home;

        public Window1(MainWindow _home)
        {
            home = _home;
            InitializeComponent();
        }
        ArrayList arj = new ArrayList();

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            Prepodavatel pr;
            pr = new Prepodavatel(Fam_Textbox.Text, textBox2.Text, textBox3.Text, Choose.Text, textBox4.Text, textBox5.Text);
            arj.Add(pr);
            using (StreamWriter sw = new StreamWriter("../../BazaD_Prepod.txt", true))
            {
                foreach (Prepodavatel p in arj)
                    sw.WriteLine("{0} {1} {2} {3} {4} {5}", pr.Fam, pr.Name, pr.Otch, pr.Predmet, pr.Log, pr.Parol);

            }
            arj.Clear();
              
            }
            catch 
            {

                MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK);
            }
            MessageBox.Show("Регистрация прошла успешно!", "" , MessageBoxButton.OK);  
        
        Close();

        }

    }
}
