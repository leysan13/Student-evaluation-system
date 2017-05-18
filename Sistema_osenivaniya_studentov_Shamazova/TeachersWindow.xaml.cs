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
    public partial class TeachersWindow : Window
    {
        private Teacher p;

        public Teacher P
        {
            get { return p; }
            set { p = value; }
        }
        List<Authorization> list;
        public void LoadList ()
         {
            BinaryFormatter formatter = new BinaryFormatter();

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
        }
        public void SaveList()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
            {
                formatter.Serialize(fs, list);
            }
        }


        public TeachersWindow(Teacher id)
        {
            p = id;
            InitializeComponent();
            Prepod.Content = p.Sername + " " + p.Name + " " + p.Patronymic + ".      " + p.Subject + ".";

        }
        List<Student> arj = new List<Student>();
        string group="";
        int mark=-1;
        string[] fio = null;
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            if (Group.Text == "")
            {
                MessageBox.Show("Выберите группу!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            arj.Clear();
            LoadList();
            foreach (Authorization el in list)
            {
                try
                {
                    Students student = (Students)el.User;
                    if (student.Group == Group.Text)
                    {
                       
                        Student st = new Student(P.Subject, student);
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
            group = Group.Text;
            mark = -1;
            fio = null;

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddStudent w3 = new AddStudent(this);
            w3.Owner = this;
            w3.Show();
            DataGrid.ItemsSource = null;
            Hide();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteStudent w4 = new DeleteStudent();
            w4.Owner = this;
            w4.Show();
            DataGrid.ItemsSource = null;
            Hide();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            MainWindow m = new MainWindow();
            m.Show();
            Close();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            LoadList();
            List<Students> listOfStudents = new List<Students>();
            foreach (Authorization el in list)
            {
                try
                {
                    Students student = (Students)el.User;
                    if (Group.Text != "")
                    {
                        if (student.Group == group)
                        {
                            listOfStudents.Add(student);

                        }
                    }
                    else
                    {   
                        if (fio!= null && mark==-1)
                        {
                            
                            if (student.Sername==fio[0] && student.Name==fio[1] && student.Patronymic==fio[2])
                            {
                                listOfStudents.Add(student);
                            }
                        }
                        else {
                            if (fio==null && mark>=0 && mark==student.GetMark(P.Subject))
                            {
                                listOfStudents.Add(student);
                            }
                            else
                            {
                                if (fio!=null && mark>=0 && student.Sername == fio[0] && student.Name == fio[1] && student.Patronymic == fio[2]&& mark == student.GetMark(P.Subject))
                                {
                                    listOfStudents.Add(student);
                                }
                            }
                        }
                    }
                }
                catch
                {

                }

            }
            for (int i = 0; i < listOfStudents.Count; i++)
            {
                listOfStudents[i].Name = arj[i].Name;
                listOfStudents[i].Sername = arj[i].Sername;
                listOfStudents[i].Patronymic = arj[i].Patronymic;
                listOfStudents[i].Group = arj[i].Group;
                switch (P.Subject)
                {
                    case "Программирование":
                        listOfStudents[i].Programming = arj[i].Mark;
                        break;
                    case "Экономика":
                        listOfStudents[i].Economics = arj[i].Mark;
                        break;
                    case "Математический анализ":
                        listOfStudents[i].Mathematical_analysis = arj[i].Mark;
                        break;
                    default:
                        break;
                }
             }
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
            SaveList();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Group.Text = "";
            if (FIO.Text == "" && Mark.Text == "")
            {
                MessageBox.Show("Для того, чтобы воспользоваться поиском, заполните все поля", "", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
            }
            if (FIO.Text != "" && Mark.Text == "")
            {
                string[] mas = FIO.Text.Split(new char[] { ' ' });
               
                if (mas.Length!=3) { MessageBox.Show("Введите правильно ФИО", "", MessageBoxButton.OK); return; }
                fio = mas;
                arj.Clear();
                LoadList();
                foreach (Authorization el in list)
                {
                    try
                    {
                        Students student = (Students)el.User;
                        if (mas[0] == student.Sername && mas[1]==student.Name&&mas[2]==student.Patronymic) {
                            Student st = new Student(P.Subject, student);
                            arj.Add(st); }
                    }
                    catch
                    {

                    }

                }
            }
            else 
            {
                if (FIO.Text == "" && Mark.Text!="")
                {
                    mark = int.Parse(Mark.Text);
                    arj.Clear();
                    LoadList();
                    foreach (Authorization el in list)
                    {
                        try
                        {
                            Students student = (Students)el.User;

                            if (int.Parse(Mark.Text) == student.GetMark(P.Subject))
                            {
                                Student st = new Student(P.Subject, student);
                                arj.Add(st);
                            }
                        }
                        catch
                        {

                        }

                    }

                
            }
                else
                {
                    if (FIO.Text != "" && Mark.Text != "")
                    {
                        string[] mas = FIO.Text.Split(new char[] { ' ' });

                        if (mas.Length != 3) { MessageBox.Show("Введите правильно ФИО", "", MessageBoxButton.OK); return; }
                        fio = mas;
                        mark = int.Parse(Mark.Text);
                        arj.Clear();
                        LoadList();
                        foreach (Authorization el in list)
                        {
                            try
                            {
                                Students student = (Students)el.User;
                                if (mas[0] == student.Sername && mas[1] == student.Name && mas[2] == student.Patronymic&& int.Parse(Mark.Text) == student.GetMark(P.Subject))
                                {
                                    Student st = new Student(P.Subject, student);
                                    arj.Add(st);
                                }
                            }
                            catch
                            {

                            }

                        }

                    }
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
            FIO.Text = "";
            Mark.Text = "";
        }

    }
}
