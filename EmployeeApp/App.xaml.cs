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
        public string[] search = new string[] { "Name", "ID", "Birthday", "Login Identifier", "Phone Number", "Email" };
        public string[] sort = new string[] { "Last Name", "First Name", "ID" };
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
            File.WriteAllText("../../json2.json", c + JsonConvert.SerializeObject(employeeList, Formatting.Indented) + " }");
        }

        public List<Employee> Search(string parameter, string criteria, List<Employee> sorted)
        {
            List<Employee> searchList = new List<Employee>();
            foreach (Employee e in sorted)
            {
                switch (criteria)
                {
                    case "Name":
                        if (e.FirstName.Contains(parameter) || e.LastName.Contains(parameter)){
                            searchList.Add(e);
                        }
                        break;
                    case "ID":
                        if (e.Id == Int32.Parse(parameter))
                        {
                            searchList.Add(e);
                        }
                        break;
                    case "Birthday":
                        if (e.Birthday.Contains(parameter))
                        {
                            searchList.Add(e);
                        }
                        break;
                    case "Login Identifier":
                        if (e.LogId.Contains(parameter))
                        {
                            searchList.Add(e);
                        }
                        break;
                    case "Phone Number":
                        if (e.Phone.Contains(parameter))
                        {
                            searchList.Add(e);
                        }
                        break;
                    case "Email":
                        if (e.Email.Contains(parameter))
                        {
                            searchList.Add(e);
                        }
                        break;
                    default:
                        Debug.WriteLine(employeeList[1].FirstName);
                        break;
                }
            }

            return searchList;
        }
        public List<Employee> Sort(List<Employee> unsort, string criteria)
        {
            List<Employee> sort;
            Employee first;
            string flname, lfname;
            bool unsorted = true;
            sort = unsort;

            if (criteria.Equals("First Name"))
            {
                while (unsorted)
                {
                    unsorted = false;
                    for (int i = 0; i < sort.Count - 1; i++)
                    {
                        
                        flname = sort[i].FirstName + sort[i].LastName;
                        if (flname.CompareTo(sort[i + 1].FirstName + sort[i + 1].LastName) > 0)
                        {
                            first = sort[i];
                            sort[i] = sort[i + 1];
                            sort[i + 1] = first;
                            unsorted = true;
                        }
                    }
                }
            }
            else if(criteria.Equals("Last Name"))
            {
                while (unsorted)
                {
                    unsorted = false;
                    for (int i = 0; i < sort.Count - 1; i++)
                    {
                        
                        lfname = sort[i].LastName + sort[i].FirstName;
                        if (lfname.CompareTo(sort[i + 1].LastName + sort[i + 1].FirstName) > 0)
                        {
                            first = sort[i];
                            sort[i] = sort[i + 1];
                            sort[i + 1] = first;
                            unsorted = true;
                        }
                    }
                }
            }
            else
            {
                while (unsorted)
                {
                    unsorted = false;
                    for (int i = 0; i < sort.Count - 1; i++)
                    { 
                        if (sort[i].Id > sort[i+1].Id)
                        {
                            first = sort[i];
                            sort[i] = sort[i + 1];
                            sort[i + 1] = first;
                            unsorted = true;
                        }
                    }
                }
            }
            return sort;
        }
    }
}
