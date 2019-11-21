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
    }
}
