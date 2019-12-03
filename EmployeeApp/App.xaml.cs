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
        public string[] search = new string[] { "Name", "LogID", "Birthday", "Identifier", "Phone Number", "Email" };
        public string[] sort = new string[] { "Last Name", "First Name", "Identifier" };
        public int count { get; set; }

        public App()
        {
            LoadJson();
        }

        void LoadJson()
        {
            using(StreamReader r = new StreamReader("../../json2.json"))
            {
                string json = r.ReadToEnd();
                JObject employees = JObject.Parse(json);
                count = (int)employees["count"];
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
            employeeList.Add(e);
            count++;
        }

        public void DeleteEmployee(string fname, string lname)
        {
            employeeList.Remove(GetEmployee(fname, lname));
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            string c = "{ \"count\": " + count + ", \"Employees\": ";
            File.WriteAllText("../../json2.json", c + JsonConvert.SerializeObject(employeeList) + " }");
        }
    }
}
