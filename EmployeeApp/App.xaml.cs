using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public List<Employee> employeeList = new List<Employee>();

        public App()
        {
            LoadJson();
        }

        void LoadJson()
        {
            using(StreamReader r = new StreamReader("C:/Users/agoun/source/repos/EmployeeManagement/EmployeeApp/json1.json"))
            {
                string json = r.ReadToEnd();
                Employee[] employeeArray = JsonConvert.DeserializeObject <Employee[]>(json);
            }
        }
    }
}
