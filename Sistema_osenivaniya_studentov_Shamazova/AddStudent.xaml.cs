using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        void W_Closing(object sender, CancelEventArgs e) {
            Owner.Show();
        }

        public AddStudent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Studentp s = new Studentp(F.Text, N.Text, O.Text, Group.Text, int.Parse(M.Text));
            Authorization Leysan = new Authorization(L.Text, P.Text, s);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Authorization> list;
            using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    list = (List<Authorization>)formatter.Deserialize(fs);
                } catch {
                    list = new List<Authorization>();
                }
            }
            list.Add(Leysan);
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
            {
                formatter.Serialize(fs, list);
            }
            Owner.Show();
            Close();
        }
    }
}
