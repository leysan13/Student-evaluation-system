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
using System.Windows.Shapes;
using System.Collections;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Prepodavatel p;
        public Window2(Prepodavatel id)
        {
            p = id;
            InitializeComponent();
            Prepod.Content = p.Fam + " " + p.Name + " " + p.Otch + ".     " + p.Predmet +".";

        }
        List<Student> arj = new List<Student>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] line = File.ReadAllLines("../../base.txt");
            for (int i = 0; i < line.Length; i++)
            {

                string[] mas = line[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Student d = new Student(mas[0], mas[1], mas[2], mas[3], int.Parse(mas[4]));
                if (mas[3] == Group.Text)
                {
                    arj.Add(d);
                    DataGrid.ItemsSource = arj;
                }

            }

            if (arj.Count == 0)
            {
                MessageBox.Show("Студенты не найдены", "", MessageBoxButton.OK);
                Close();
            }
            arj.Clear();
        }
    }
}
