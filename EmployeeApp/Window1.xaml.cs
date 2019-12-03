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
        Employee empty;
        public Window1()
        {
            InitializeComponent();
            Access.ItemsSource = ((App)Application.Current).access;
            ID.Text = ((App)Application.Current).count.ToString();
        }

        public Window1(Employee e)
        {
            InitializeComponent();
            ID.Text = e.Id.ToString();
            FirstName.Text = e.FirstName;
            LastName.Text = e.LastName;
            LoginId.Text = e.LogId;
            Birthday.Text = e.Birthday;
            Email.Text = e.Email;
            Phone.Text = e.Phone;
            Access.ItemsSource = ((App)Application.Current).access;
            Access.SelectedItem = e.AccessLevel;
            empty = e;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow select = new MainWindow();
            select.Show();
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(empty == null)
            {
                ((App)Application.Current).AddEmployee(new Employee(Int32.Parse(ID.Text), FirstName.Text, LastName.Text, LoginId.Text, Birthday.Text, Email.Text, Phone.Text, Access.Text));
            }
            else
            {
                if(empty.FirstName != FirstName.Text)
                {
                    empty.FirstName = FirstName.Text;
                }
                if (empty.LastName != LastName.Text)
                {
                    empty.LastName = LastName.Text;
                }
                if (empty.Phone != Phone.Text)
                {
                    empty.Phone = Phone.Text;
                }
                if (empty.Birthday != Birthday.Text)
                {
                    empty.Birthday = Birthday.Text;
                }
                if (empty.Email != Email.Text)
                {
                    empty.Email = Email.Text;
                }
                if (empty.AccessLevel != Access.Text)
                {
                    empty.AccessLevel = Access.Text;
                }
            }
            MainWindow select = new MainWindow();
            select.Show();
            this.Close();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length < 1)
            {
                LoginId.Text = LastName.Text.ToLower();
            }
            else
            {
                LoginId.Text = (FirstName.Text.ToCharArray(0, 1)[0] + LastName.Text).ToLower();
            }
            
        }
    }
}
