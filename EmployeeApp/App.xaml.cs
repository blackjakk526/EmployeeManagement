using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace EmployeeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public List<Employee> employeeList = new List<Employee>();
        public string[] access = new string[] { "Standard", "Experienced", "Advanced", "Administrator", "Super" };

        public App()
        {
            LoadJson();
        }

        void LoadJson()
        {
            using(StreamReader r = new StreamReader("../../json1.json"))
            {
                string json = r.ReadToEnd();
                JObject employees = JObject.Parse(json);
                JArray array = (JArray)employees["Employees"];
                employeeList = array.ToObject<List<Employee>>();
                //Debug.WriteLine(employeeList[1].FirstName);
            }
        }

        public Employee GetEmployee(string fname, string lname)
        {
            foreach(Employee e in employeeList)
            {
                if(string.Compare(e.FirstName, fname) == 0 && string.Compare(e.LastName, lname) == 0)
                {
                    return e;
                }
            }

            return null;
        }

        public void AddEmployee(Employee e)
        {

        }
    }
}
