﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
           
            Window1 w1 = new Window1();
            w1.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
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
            foreach (Authorization x in list)
            {
                if (x.Login == LoginText.Text && x.Parol == PasswordText.Text)
                {
                    try
                    {
                        new Window2((Prepodavatel)x.User).Show();
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Студентам доступ временно закрыт.\nВедутся разработки", "Невозможная операция", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    return;
                }
            }
            MessageBox.Show("Неверный логин или пароль.", "", MessageBoxButton.OK);

        }
        
        
        
    }
}
