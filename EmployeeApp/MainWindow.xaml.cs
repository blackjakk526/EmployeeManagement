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
using System.Diagnostics;

namespace EmployeeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> a;
        public MainWindow()
        {
            InitializeComponent();
           
            a = ((App)Application.Current).employeeList;
            //Debug.WriteLine(a[0].FirstName);
            for (int i = 0; i < a.Count; i++)
            {
                NameBox.Items.Add(a[i].FirstName + " " + a[i].LastName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("I made it here");
            Window1 select = new Window1(a[1]);
            select.Show();
            this.Close();
        }
    }
}
