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

        //reads in json file when application opens
        public App()
        {
            LoadJson();
        }

        //reads in the json file with the employee data
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

        //returns the employee object when given the arguments of the first and last name of employee, returns null if not found
        public Employee GetEmployee(string fname, string lname)
        {
            foreach(Employee e in employeeList)
            {
                //checks for a match 
                if(string.Compare(e.FirstName, fname) == 0 && string.Compare(e.LastName, lname) == 0)
                {
                    return e;
                }
            }

            return null;
        }

        //adds employee to the list which is the main list object with all the employee data
        public void AddEmployee(Employee e)
        {
            employeeList.Add(e);
            count++;
        }

        //deletes employee from the main list
        public void DeleteEmployee(string fname, string lname)
        {
            employeeList.Remove(GetEmployee(fname, lname));
        }

        //saves the list of employees as well as the count as a json file to store
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            string c = "{ \"count\": " + count + ", \"Employees\": ";
            File.WriteAllText("../../json2.json", c + JsonConvert.SerializeObject(employeeList, Formatting.Indented) + " }");
        }

        //searchs for the employee/employees when given a search criteria area and text that is being searched in that area
        public List<Employee> Search(string parameter, string criteria, List<Employee> sorted)
        {
            List<Employee> searchList = new List<Employee>();
            foreach (Employee e in sorted)
            {
                switch (criteria)
                {
                    case "Name":
                        string name = e.FirstName + " " + e.LastName;
                        if (name.ToLower().Contains(parameter.ToLower())){
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
                        if (e.LogId.ToLower().Contains(parameter.ToLower()))
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
                        if (e.Email.ToLower().Contains(parameter.ToLower()))
                        {
                            searchList.Add(e);
                        }
                        break;
                    default:
                        Debug.WriteLine("Wrong information sent");
                        break;
                }
            }

            return searchList;
        }

        //sorts the list on the window by the given combobox criteria
        public List<Employee> Sort(List<Employee> unsort, string criteria)
        {
            List<Employee> sort;
            Employee first;
            string flname, lfname;
            bool unsorted = true;
            sort = unsort;

            //sorts by first name when selected 
            if (criteria.Equals("First Name"))
            {
                while (unsorted)
                {
                    unsorted = false;
                    for (int i = 0; i < sort.Count - 1; i++)
                    {
                        //combines first and last name to improve efficiency 
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
            //sorts by last name when selected in combobox
            else if(criteria.Equals("Last Name"))
            {
                while (unsorted)
                {
                    unsorted = false;
                    for (int i = 0; i < sort.Count - 1; i++)
                    {
                        //combines the last name with the first (in that order) to improve efficiency
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
            //sorts by Id given by the system when employee was added.
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
