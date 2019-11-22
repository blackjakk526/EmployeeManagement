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
using System.Windows.Shapes; 

namespace EmployeeApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Access.ItemsSource = ((App)Application.Current).access;
        }

        public Window1(Employee e)
        {
            InitializeComponent();
            FirstName.Text = e.FirstName;
            LastName.Text = e.LastName;
            LoginId.Text = e.LogId;
            Birthday.Text = e.Birthday;
            Email.Text = e.Email;
            Phone.Text = e.Phone;
            Access.ItemsSource = ((App)Application.Current).access;
            Access.SelectedItem = e.AccessLevel;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow select = new MainWindow();
            select.Show();
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            
    }
}
