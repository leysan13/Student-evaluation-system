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
using System.Xml.Serialization;

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
            NavigationWindow win = new NavigationWindow();
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            win.Height = screenHeight;
            win.Top = 0;
            win.Width = screenWidth;
            win.Left = 0;
            win.Content = new Entrance();
           // win.Icon = "../../personal_7148.ico";
            win.ShowsNavigationUI = false;
            win.Show();
            Close();
        }

       

    }
}
