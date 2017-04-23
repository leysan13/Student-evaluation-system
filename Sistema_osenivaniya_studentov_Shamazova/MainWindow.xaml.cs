using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
           
            Window1 w1 = new Window1();
            w1.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Prepodavatel d = null;
            string[] line = File.ReadAllLines("../../BazaD_Prepod.txt");
            for (int i = 0; i < line.Length; i++)
            {
                string[] mas = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                d = new Prepodavatel(mas[0], mas[1], mas[2], mas[3], mas[4], mas[5]);
                if (mas[4] == LoginText.Text && mas[5] == PasswordText.Text)
                {
                    break;
                }
                d = null;
            }
            if (d == null)
            {
                MessageBox.Show("Неверный логин или пароль.", "", MessageBoxButton.OK);
            }
            else
            {
                Window2 w2 = new Window2(d);
                w2.Show();
                Close();
            }

        }
        
    }
}
