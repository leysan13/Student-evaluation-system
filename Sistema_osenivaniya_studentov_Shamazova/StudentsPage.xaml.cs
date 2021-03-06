﻿using System;
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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        private Students st;

        public Students St
        {
            get { return st; }
            set { st = value; }
        }

        public StudentsPage(Students id)
        {
            InitializeComponent();
            St = id;
            StudentName.Content = St.Sername + " " + St.Name + " " + St.Patronymic + ", группа " + St.Group;
            List<Marks> arj = new List<Marks>();
            arj.Add(St.marks);
            Datagrid.ItemsSource = null;
           Datagrid.ItemsSource = arj;
            Exit.Focus();
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            St = null;
            Datagrid.ItemsSource = null;
            StudentName.Content = "";
            NavigationService.Navigate(new Entrance());
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            Exit.FontSize += 2;
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            Exit.FontSize -= 2;
        }
    }
}
