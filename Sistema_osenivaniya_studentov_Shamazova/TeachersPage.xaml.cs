using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        private Teacher p;

        public Teacher P
        {
            get { return p; }
            set { p = value; }

        }
        public TeachersPage(Teacher id)
        {

            p = id;
            InitializeComponent();
            Prepod.Content = p.Sername + " " + p.Name + " " + p.Patronymic + ".      " + p.Subject + ".";
            if (P == null) { NavigationService.Navigate(new Entrance()); }

        }
        List<Student> arj = new List<Student>();
        string group = "";
        int mark = -1;
        string[] fio = null;
        
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (P == null) { NavigationService.Navigate(new Entrance()); return; }
            Group.Text = "";
            if (FIO.Text == "" && Mark.Text == "")
            {
                MessageBox.Show("Для того, чтобы воспользоваться поиском, заполните все поля", "", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
            }
            if (FIO.Text != "" && Mark.Text == "")
            {
                string[] mas = FIO.Text.Split(new char[] { ' ' });

                if (mas.Length != 3) { MessageBox.Show("Введите правильно ФИО", "", MessageBoxButton.OK); return; }
                fio = mas;
                arj.Clear();
                List<Authorization> list = new Serialization().Deserialize();
                foreach (Authorization el in list)
                {
                    try
                    {
                        Students student = (Students)el.User;
                        if (mas[0] == student.Sername && mas[1] == student.Name && mas[2] == student.Patronymic)
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
                if (FIO.Text == "" && Mark.Text != "")
                {
                    mark = int.Parse(Mark.Text);
                    arj.Clear();
                    List<Authorization> list = new Serialization().Deserialize();
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
                        List<Authorization> list = new Serialization().Deserialize();
                        foreach (Authorization el in list)
                        {
                            try
                            {
                                Students student = (Students)el.User;
                                if (mas[0] == student.Sername && mas[1] == student.Name && mas[2] == student.Patronymic && int.Parse(Mark.Text) == student.GetMark(P.Subject))
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
                SaveChanges.IsEnabled = false;
                return;
            }
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = arj;
            FIO.Text = "";
            Mark.Text = "";
            SaveChanges.IsEnabled = DataGrid.ItemsSource != null;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (P == null) { NavigationService.Navigate(new Entrance()); return; }
                Serialization ser = new Serialization();
                List<Authorization> list = ser.Deserialize();
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
                            if (fio != null && mark == -1)
                            {

                                if (student.Sername == fio[0] && student.Name == fio[1] && student.Patronymic == fio[2])
                                {
                                    listOfStudents.Add(student);
                                }
                            }
                            else
                            {
                                if (fio == null && mark >= 0 && mark == student.GetMark(P.Subject))
                                {
                                    listOfStudents.Add(student);
                                }
                                else
                                {
                                    if (fio != null && mark >= 0 && student.Sername == fio[0] && student.Name == fio[1] && student.Patronymic == fio[2] && mark == student.GetMark(P.Subject))
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
                int t=1;
                int m;
                for (int i = 0; i < listOfStudents.Count; i++)
                {
                    if ((arj[i].Group == "ББИ161" || arj[i].Group == "ББИ162" || arj[i].Group == "ББИ163" || arj[i].Group == "ББИ164" || arj[i].Group == "ББИ165" || arj[i].Group == "ББИ166" || arj[i].Group == "ББИ167" || arj[i].Group == "ББИ168") == false || (0 <= arj[i].Mark && arj[i].Mark <= 10) == false)
                    {
                        MessageBox.Show("Изменения должны быть корректными", "!", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
                    }
                    if (arj[i].Name == "" || arj[i].Sername == "" || arj[i].Patronymic == "")
                    {
                        MessageBox.Show("Не оставляйте поля пустыми", "!", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
                    }
                    try
                    {
                        m = int.Parse(arj[i].Name);
                        t = 0;
                    }
                    catch 
                    {
                    }
                    try
                    {
                        m = int.Parse(arj[i].Sername);
                        t = 0;
                    }
                    catch
                    {
                    }
                    try
                    {
                        m = int.Parse(arj[i].Patronymic);
                        t = 0;
                    }
                    catch
                    {
                    }
                    if (t==0)
                    {
                        MessageBox.Show("ФИО должны быть записаны буквами", "!", MessageBoxButton.OK, MessageBoxImage.Exclamation); return;
                    }
                    listOfStudents[i].Name = arj[i].Name;
                    listOfStudents[i].Sername = arj[i].Sername;
                    listOfStudents[i].Patronymic = arj[i].Patronymic;
                    listOfStudents[i].Group = arj[i].Group;
                    switch (P.Subject)
                    {
                        case "Программирование":
                            listOfStudents[i].marks.Programming = arj[i].Mark;
                            break;
                        case "Экономика":
                            listOfStudents[i].marks.Economics = arj[i].Mark;
                            break;
                        case "Математический анализ":
                            listOfStudents[i].marks.Mathematical_analysis = arj[i].Mark;
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
                ser.Serialize(list);
            }
            catch 
            {
                MessageBox.Show("Произошла ошибка, возможно, Вы неккоректно ввели данные","Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            P = null;
            DataGrid.ItemsSource = null;
            SaveChanges.IsEnabled = false;
            NavigationService.Navigate(new Entrance());
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            if (P == null) { NavigationService.Navigate(new Entrance()); return; }
            if (Group.Text == "")
            {
                MessageBox.Show("Выберите группу!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            arj.Clear();
            List<Authorization> list = new Serialization().Deserialize();
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
                SaveChanges.IsEnabled = false;
                return;
            }
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = arj;
            group = Group.Text;
            mark = -1;
            fio = null;
            SaveChanges.IsEnabled = DataGrid.ItemsSource != null;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (P == null) { NavigationService.Navigate(new Entrance()); return; }
            DataGrid.ItemsSource = null;
            NavigationService.Navigate(new AddStudentPage(P));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (P == null) { NavigationService.Navigate(new Entrance()); return; }
            DataGrid.ItemsSource = null;
            NavigationService.Navigate(new DeleteStudentPage());
        }
        int y;
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            int selectedindex = DataGrid.SelectedIndex;
            if (selectedindex == -1)

            {
                MessageBox.Show("Для удаления нужно что-то выбрать");
            }
            else
            {
                MessageBoxResult answer;
                answer = MessageBox.Show("Вы точно хотите безвозвратно удалить студента " +arj[selectedindex].Sername+" " +arj[selectedindex].Name +" "+arj[selectedindex].Patronymic+ "?", "Удаление данных", MessageBoxButton.OKCancel);
                
                if (answer == MessageBoxResult.OK)
                {

                     Serialization ser = new Serialization();
                    List<Authorization> list = ser.Deserialize();
                    for (int i = 0; i < list.Count; i++)
                    {
                        try
                        {
                            Students s = (Students)list[i].User;
                            if (s.Name == arj[selectedindex].Name && s.Sername == arj[selectedindex].Sername && s.Patronymic == arj[selectedindex].Patronymic && s.Group == arj[selectedindex].Group)
                            {
                            y = i;

                            }
                        }
                        catch
                        {
                        }
                    }
                    list.Remove(list[y]);
                    arj.RemoveAt(selectedindex);

                    DataGrid.ItemsSource = null;
                    DataGrid.Columns.Clear();
                    DataGrid.ItemsSource = arj;
                   
                    ser.Serialize(list);



                }
            }

            }

        private void Show_MouseEnter(object sender, MouseEventArgs e)
        {

            Show.Width += 2;
        }

        private void Show_MouseLeave(object sender, MouseEventArgs e)
        {

            Show.Width -= 2;
        }

        private void Add_MouseEnter(object sender, MouseEventArgs e)
        {
            Add.Width += 2;
        }

        private void Add_MouseLeave(object sender, MouseEventArgs e)
        {
            Add.Width -= 2;
        }

        private void Delete_MouseEnter(object sender, MouseEventArgs e)
        {
            Delete.Width += 2;
        }

        private void Delete_MouseLeave(object sender, MouseEventArgs e)
        {
            Delete.Width -= 2;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelUnderFIO.FontSize = 10;
        }

        private void LabelUnderFIO_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelUnderFIO.FontSize = 8;
        }

        private void Search_MouseEnter(object sender, MouseEventArgs e)
        {
            Search.Width += 2;
        }

        private void Search_MouseLeave(object sender, MouseEventArgs e)
        {
            Search.Width -= 2;
        }
        
        private void Del_MouseEnter(object sender, MouseEventArgs e)
        {
            

        }
    }
}
