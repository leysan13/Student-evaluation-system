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
    /// Логика взаимодействия для DeleteStudentPage.xaml
    /// </summary>
    public partial class DeleteStudentPage : Page
    {
        Teacher P;
        public DeleteStudentPage(Teacher id)
        {
            P = id;
            InitializeComponent();
            FIO.Focus();
        }
        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            if ((FIO.Text == "") || (Group.Text == ""))
            {
                MessageBox.Show("Заполните все поля!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                Serialization ser = new Serialization();
                List<Authorization> list = ser.Deserialize();
                string[] mas = FIO.Text.Split(new char[] { ' ' });
                if (mas.Length < 3)
                {
                    MessageBox.Show("Заполните поле 'ФИО' должным образом.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (mas.Length > 3)
                {
                    MessageBox.Show("Заполните поле 'ФИО' должным образом. \nСлишком много данных в одной строке.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                bool t = false;
                foreach (Authorization student in list)
                {
                    try
                    {
                        Students st = (Students)student.User;
                        if ((mas[0] == st.Sername) && (mas[1] == st.Name) && (mas[2] == st.Patronymic) && (Group.Text == st.Group))
                        {
                            //P.AddHistoryChange(student, null);
                            list.Remove(student);
                            ser.Serialize(list);
                            MessageBox.Show("Удаление завершено", "-", MessageBoxButton.OK);
                            FIO.Text = "";
                            Group.Text = "";
                           
                            t = true;
                            break;
                        }
                    }
                    catch { }

                }
                if (t == false)
                { MessageBox.Show("Студент не найден", "-", MessageBoxButton.OK); }
               
            }
        
    }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
