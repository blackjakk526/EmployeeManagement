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
            Window1 select = new Window1();
            select.Show();
            this.Close();
        }

        private void NameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("I made it here");
            if (NameBox.SelectedItem != null) {
                string[] name = NameBox.SelectedItem.ToString().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                Employee employee = ((App)Application.Current).GetEmployee(name[0], name[1]);
                Window1 select = new Window1(employee);
                select.Show();
                this.Close();
            }
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
