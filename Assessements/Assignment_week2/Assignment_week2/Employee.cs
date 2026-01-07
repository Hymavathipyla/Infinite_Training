using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_week2
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; } 

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Dept: {Department}, Salary: {Salary}, Exp: {Experience} years";
        }

    }
}

