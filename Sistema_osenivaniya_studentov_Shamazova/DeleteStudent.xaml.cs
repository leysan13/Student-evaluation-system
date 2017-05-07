using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для DeleteStudent.xaml
    /// </summary>
    public partial class DeleteStudent : Window
    {
            void W_Closing(object sender, CancelEventArgs e)
            {
                Owner.Show();
            }
            public DeleteStudent()
        {
            InitializeComponent();
        }
    }
}
