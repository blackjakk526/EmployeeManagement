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
            for (int i = 0; i < a.Count; i++)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = ((App)Application.Current).employeeList;

        }
    }
}