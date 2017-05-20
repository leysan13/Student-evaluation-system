using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class Entrance : Page
    {
        public Entrance()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            List<Authorization> list = new Serialization().Deserialize();
            foreach (Authorization x in list)
            {
                if (x.Login == LoginText.Text && x.Password == Password.Password)
                {
                    try
                    {
                        NavigationService.Navigate(new TeachersPage((Teacher)x.User));
                    }
                    catch
                    {
                        NavigationService.Navigate(new StudentsPage((Students)x.User));
                    }
                    return;
                }
            }
            MessageBox.Show("Неверный логин или пароль.", "", MessageBoxButton.OK);

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
