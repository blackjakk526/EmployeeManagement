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
        //list of employees that is displayed even after certain criteria has been selected, previous to allow some back peddling in the search field
        List<Employee> a, previous;
        //string text that is used to compare that the text has been reduced or deleted
        string p;
        public MainWindow()
        {
            InitializeComponent();
           
            a = ((App)Application.Current).employeeList;
            Sort.ItemsSource = ((App)Application.Current).sort;
            Parameters.ItemsSource = ((App)Application.Current).search;
            //Debug.WriteLine(a[0].FirstName);
        }

        //Add click event for the blank add window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 select = new Window1();
            select.Show();
            this.Close();
        }

        //double clicking event on the list that also allows to edit the employee information
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

        //same as double click but as a edit button, allowing to edit employee information
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if(NameBox.SelectedItem != null)
            {
                string[] name = NameBox.SelectedItem.ToString().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                Employee employee = ((App)Application.Current).GetEmployee(name[0], name[1]);
                Window1 select = new Window1(employee);
                select.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a name from the list to edit", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Event that keeps the list updated to show the present search text
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

            NameBox.Items.Clear();
            //warning if no parameter has been selected from the combobox
            if (Parameters.SelectedItem == null)
            {
                MessageBox.Show("Please select a parameter from the list to search", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //makes sure that if the field is blank, then the whole employee list is shown
                if (Search.Text.Length < 1)
                {
                    a = ((App)Application.Current).employeeList;
                }
                //checks if some text has been deleted to update the list, only allows one backspace
                else if (p != null && p.Length > Search.Text.Length && previous != null)
                {
                    p = Search.Text;
                    a = ((App)Application.Current).Search(Search.Text, Parameters.Text, previous);
                    previous = a;
                }
                else
                {
                    p = Search.Text;
                    previous = a;
                    a = ((App)Application.Current).Search(Search.Text, Parameters.Text, previous);
                }
                //apply the new list with the search criteria added
                for (int i = 0; i < a.Count; i++)
                {
                    NameBox.Items.Add(a[i].FirstName + " " + a[i].LastName);
                }
            }
        }

        //goes to the sort function when a new selection has been made, updates the list
        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            NameBox.Items.Clear();
            a = ((App)Application.Current).Sort(a, Sort.SelectedItem.ToString());
            for (int i = 0; i < a.Count; i++)
            {
                NameBox.Items.Add(a[i].FirstName + " " + a[i].LastName);
            }
           
        }

        //author information display window, performed as a double click on the label
        private void Info_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("***********************", "Author Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //deletes the employee from the list and from the main list employee object
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if(NameBox.SelectedItem != null)
            {
                string[] name = NameBox.SelectedItem.ToString().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                ((App)Application.Current).DeleteEmployee(name[0], name[1]);
                NameBox.Items.Remove(NameBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a name from the list to delete", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
