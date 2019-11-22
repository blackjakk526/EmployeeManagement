using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Employee
    {
        private string fname, lname, logId, birthDay, email, phone, accessLevel;

        public string LastName { get => lname; set => lname = value; }
        public string LogId { get => logId; set => logId = value; }
        public string Birthday { get => birthDay; set => birthDay = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string AccessLevel { get => accessLevel; set => accessLevel = value; }
        public string FirstName { get => fname; set => fname = value; }
        public int Id { get; set; }


        public Employee()
        {

        }

        public Employee(int i, string first, string last, string login, string birth, string emailAdd, string phoneNum, string accessLev)
        {
            Id = i;
            FirstName = first;
            LastName = last;
            LogId = login;
            Birthday = birth;
            Email = emailAdd;
            Phone = phoneNum;
            AccessLevel = accessLev;
        }
    }
}
