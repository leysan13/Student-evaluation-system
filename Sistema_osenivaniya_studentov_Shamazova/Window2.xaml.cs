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
using System.Runtime.Serialization.Formatters.Binary;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Prepodavatel p;

        public Prepodavatel P
        {
            get { return p; }
            set { p = value; }
        }

        public Window2(Prepodavatel id)
        {
            p = id;
            InitializeComponent();
            Prepod.Content = p.Sername + " " + p.Name + " " + p.Patronymic + ".      " + p.Predmet +".";

        }
        List<Student> arj = new List<Student>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            arj.Clear();
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
            foreach (Authorization el in list)
            {
                try
                {
                    Students s = (Students)el.User;
                    if (s.Group == Group.Text)
                    {
                        int mark;
                        switch (P.Predmet)
                        {
                            case "Программирование":
                                mark = s.Programing;
                                break;
                            case "Экономика":
                                mark = s.Econ;
                                break;
                            case "Математический анализ":
                                mark = s.Mathematical_analysis;
                                break;
                            default:
                                mark = 0;
                                break;
                        }
                        Student st = new Student(s.Sername, s.Name, s.Patronymic, s.Group, mark);
                        arj.Add(st);
                    }
                }
                catch
                {

                }
               
            }
            


            if (arj.Count == 0)
            {
                MessageBox.Show("Студенты не найдены", "", MessageBoxButton.OK);
                DataGrid.ItemsSource = null;
                return;
            }
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = arj;
            

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddStudent w3 = new AddStudent();
            w3.Owner = this;
            w3.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteStudent w4 = new DeleteStudent();
            w4.Owner = this;
            w4.Show();
            Hide();
        }
    }
}
