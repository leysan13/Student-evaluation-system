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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        Teacher P;
        Serialization ser;
        List<Authorization> list = new List<Authorization>();
       
        public History(Teacher Pr)
        {
           ser  = new Serialization();

            P = Pr;
            InitializeComponent();
            RefreshListBox();
            
        }
        public void RefreshListBox()
        {
            list = ser.Deserialize();
            string[] mas = new string[10];
            for (int i = 0; i < P.History.Count; i++)
            {
                Students sb;
                Students sa;

                if (P.History[i].StudentBefore.Login == "-1" && P.History[i].StudentAfter.Login == "-1")
                {
                    mas[i] = "-";
                    continue;
                }


                if (P.History[i].StudentAfter.Login == "-1" && P.History[i].StudentBefore.Login != "-1")
                {
                    sb = (Students)P.History[i].StudentBefore.User;
                    mas[i] = "Студент " + sb.Sername + " " + sb.Name + " " + sb.Patronymic + " ( " + sb.Group + " ) был удалён;";
                    continue;
                }
                if (P.History[i].StudentAfter.Login != "-1" && P.History[i].StudentBefore.Login == "-1")
                {
                    sa = (Students)P.History[i].StudentAfter.User;
                    mas[i] = "Студент " + sa.Sername + " " + sa.Name + " " + sa.Patronymic + " ( " + sa.Group + " ) был добавлен;";
                    continue;
                }

                sb = (Students)P.History[i].StudentBefore.User;
                sa = (Students)P.History[i].StudentAfter.User;
                int markB;
                int markA;
                switch (P.Subject)
                {
                    case "Программирование":
                        markB = sb.marks.Programming;
                        markA = sa.marks.Programming;
                        break;
                    case "Экономика":
                        markB = sb.marks.Economics;
                        markA = sa.marks.Economics;
                        break;
                    case "Математический анализ":
                        markB = sb.marks.Mathematical_analysis;
                        markA = sa.marks.Mathematical_analysis;
                        break;
                    default:
                        markB = 0;
                        markA = 0;
                        break;
                }
                mas[i] = "Данные студента: " + sb.Sername + " " + sb.Name + " " + sb.Patronymic + " ( " + sb.Group + " ), оценка " + markB + ", были изменены на " + sa.Sername + " " + sa.Name + " " + sa.Patronymic + " ( " + sa.Group + " ), оценка " + markA+" ;";
            }

            listbox.ItemsSource = mas;
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteChanges_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItems.Count==0)
            {
                MessageBox.Show("Вы ничего не выбрали","Отмена изменений",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                return;
                }
            string str = listbox.SelectedItem as string;
            string[] line = str.Split(' ');
            Authorization x = new Authorization("-1","-1", new Students("-1","-1","-1","-1","-1",-1));
            switch (line[line.Length-1])
            {
                case "-":
                    MessageBox.Show("В этой строке изменений нет", "",MessageBoxButton.OK);
                    break;
                case " ":
                    MessageBox.Show("В этой строке изменений нет", "", MessageBoxButton.OK);
                    break;
                case "удалён;":
                   
                    for (int i = 0; i < P.History.Count; i++)
                    {
                        Students stb = (Students)P.History[i].StudentBefore.User;
                        Students sta = (Students)P.History[i].StudentAfter.User;
                        if (stb.Sername==line[1]&&stb.Name==line[2]&&stb.Patronymic==line[3]&&stb.Group==line[5]&&sta.Name=="-1")
                        {
                            foreach (Authorization aut in list)
                            {
                                try
                                {
                                    Students s = aut.User as Students;
                                    if (s.Name== stb.Name&&s.Sername==stb.Sername&&s.Patronymic==stb.Patronymic&&s.Group==stb.Group)
                                    {
                                        MessageBox.Show("Данный студент уже существует. Возможно, Вы его уже восстановили","-",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                                        return;
                                     }
                                }
                                catch
                                {

                                }

                            }
                            list.Add(P.History[i].StudentBefore);
                            P.History.RemoveAt(i);
                            foreach (Authorization X in list)
                            {
                                try
                                {
                                    Teacher t = (Teacher)X.User;
                                    if (P.Name == t.Name && P.Sername == t.Sername && P.Subject == t.Subject && P.Patronymic == t.Patronymic)
                                    {

                                        t.History = P.History;
                                    }
                                }
                                catch { }
                            }
                            ser.Serialize(list);
                            RefreshListBox();
                            MessageBox.Show("Данные о студенте восстановлены","-",MessageBoxButton.OK);
                            return;
                        }
                    }
                    break;
                case "добавлен;":
                    for (int i = 0; i < P.History.Count; i++)
                    {
                        Students stb = (Students)P.History[i].StudentBefore.User;
                        Students sta = (Students)P.History[i].StudentAfter.User;
                        if (sta.Sername == line[1] && sta.Name == line[2] && sta.Patronymic == line[3] && sta.Group == line[5] && stb.Name == "-1")
                        {
                            
                            int v=-1;
                            for (int j=0; j<list.Count; j++)
                            {try
                                {
                                    if (((Students)list[j].User).Name == sta.Name && ((Students)list[j].User).Sername == sta.Sername && ((Students)list[j].User).Patronymic == sta.Patronymic && ((Students)list[j].User).Group == sta.Group)
                                    {
                                        v = j;
                                    }
                                }
                                catch { }
                            }
                            if (v==-1)
                            {
                                MessageBox.Show("Данных этого студента нет. Возможно, Вы уже удалили его данные.", "-", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                return;
                            }
                            list.RemoveAt(v);
                            P.History.RemoveAt(i);
                            foreach (Authorization X in list)
                            {
                                try
                                {
                                    Teacher t = (Teacher)X.User;
                                    if (P.Name == t.Name && P.Sername == t.Sername && P.Subject == t.Subject && P.Patronymic == t.Patronymic)
                                    {

                                        t.History = P.History;
                                    }
                                }
                                catch { }
                            }
                            ser.Serialize(list);
                            RefreshListBox();
                            MessageBox.Show("Добавление студента отменено", "-", MessageBoxButton.OK);
                            return;
                        }
            }

                    break;

                case ";":
                    for (int i = 0; i < P.History.Count; i++)
                    {
                        Students sta = (Students)P.History[i].StudentAfter.User;
                        Students stb = (Students)P.History[i].StudentBefore.User;
                        Student sa = new Student(P.Subject, sta);
                        Student sb = new Student(P.Subject, stb);
                        if (stb.Sername == line[2] && stb.Name == line[3] && stb.Patronymic == line[4] && stb.Group == line[6] && sta.Sername == line[13] && sta.Name == line[14] && sta.Patronymic == line[15] && sta.Group == line[17])
                        {
                            int v = -1;
                            for (int j = 0; j < list.Count; j++)
                            {
                                try
                                {
                                    Student s = new Student(P.Subject, (Students)list[j].User);
                                    if (((Students)list[j].User).Name == sta.Name && ((Students)list[j].User).Sername == sta.Sername && ((Students)list[j].User).Patronymic == sta.Patronymic && ((Students)list[j].User).Group == sta.Group&&sa.Mark==s.Mark)
                                    {
                                        v = j;
                                    }
                                }
                                catch { }
                            }
                            if (v == -1)
                            {
                                MessageBox.Show("Данных измененного студента нет. Возможно, Вы уже удалили его данные.", "-", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                return;
                            }
                            list.RemoveAt(v);
                            foreach (Authorization aut in list)
                            {
                                try
                                {
                                    Students s = aut.User as Students;
                                    Student sc = new Student(P.Subject, (Students)aut.User);
                                    if (s.Name == stb.Name && s.Sername == stb.Sername && s.Patronymic == stb.Patronymic && s.Group == stb.Group&&sc.Mark==sb.Mark)
                                    {
                                        MessageBox.Show("Данный студент уже существует. Возможно, Вы его уже восстановили", "-", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                        return;
                                    }
                                }
                                catch
                                {

                                }

                            }
                            list.Add(P.History[i].StudentBefore);
                            P.History.RemoveAt(i);
                            foreach (Authorization X in list)
                            {
                                try
                                {
                                    Teacher t = (Teacher)X.User;
                                    if (P.Name == t.Name && P.Sername == t.Sername && P.Subject == t.Subject && P.Patronymic == t.Patronymic)
                                    {

                                        t.History = P.History;
                                    }
                                }
                                catch { }
                            }
                           
                            ser.Serialize(list);
                            RefreshListBox();
                            MessageBox.Show("Данные о студенте восстановлены", "-", MessageBoxButton.OK);
                            break;
                        }
                    }
                    
                    
                    break;

                default:
                    break;
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
        }
    }
    }
