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
        public History(Teacher P)
        {
           
            InitializeComponent();
            //string[] mas = new string[10];
            //for (int i = 0; i < P.History.Count; i++)
            //{
            //    Students sb;
            //    Students sa;

            //        if (P.History[i].StudentBefore.Login == "-")
            //        {
            //            mas[i] = "-";
            //        continue;
            //        }


            //        if (P.History[i].StudentAfter.Login == "-")
            //        {
            //            sb = (Students)P.History[i].StudentBefore.User;
            //            mas[i] = "Студент " + sb.Sername + " " + sb.Name + " " + sb.Patronymic + " (" + sb.Group + ") был удалён.";
            //        continue;
            //        }
               
              
            //           sb = (Students)P.History[i].StudentBefore.User;
            //           sa = (Students)P.History[i].StudentAfter.User;
            //            int markB;
            //            int markA;
            //            switch (P.Subject)
            //            {
            //                case "Программирование":
            //                    markB = sb.marks.Programming;
            //                    markA = sa.marks.Programming;
            //                    break;
            //                case "Экономика":
            //                    markB = sb.marks.Economics;
            //                    markA = sa.marks.Economics;
            //                    break;
            //                case "Математический анализ":
            //                    markB = sb.marks.Mathematical_analysis;
            //                    markA = sa.marks.Mathematical_analysis;
            //                    break;
            //                default:
            //                    markB = 0;
            //                    markA = 0;
            //                    break;
            //            }
            //            mas[i] = "Данные студента: " + sb.Sername + " " + sb.Name + " " + sb.Patronymic + " (" + sb.Group + "), оценка "+markB+", были изменены на " + sa.Sername + " " + sa.Name + " " + sa.Patronymic + " (" + sa.Group + "), оценка " + markA;
            //        }
           
            //listbox.ItemsSource = mas;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
    }
