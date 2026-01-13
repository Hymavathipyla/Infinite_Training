using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class HRpayroll
    {
        public class EmployeeRecord
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public bool IsVeteran { get; set; }
        }


        public interface IEmployeeDataReader
        {
            EmployeeRecord GetEmployeeRecord(int employeeId);
        }


        public class MockEmployeeDataReader : IEmployeeDataReader
        {
            public EmployeeRecord GetEmployeeRecord(int employeeId)
            {
                //public EmployeeRecord GetEmployeeRecord(int employeeId) => employeeId switch
                //{
                //    101 => new EmployeeRecord { Id = 101, Name = "Hyma", Role = "Developer", IsVeteran = false },
                //    102 => new EmployeeRecord { Id = 102, Name = "Bhavana", Role = "Manager", IsVeteran = true },          // Pattern Matching new feature am not able to do in my vs code version because of the version //
                //    103 => new EmployeeRecord { Id = 103, Name = "Hyra", Role = "Intern", IsVeteran = false },
                //    _ => new EmployeeRecord { Id = employeeId, Name = "krishna", Role = "Other", IsVeteran = false }
                //};

                switch (employeeId)
                {
                    case 101:
                        return new EmployeeRecord { Id = 101, Name = "Hyma", Role = "Developer", IsVeteran = false };
                    case 102:
                        return new EmployeeRecord { Id = 102, Name = "pyla", Role = "Manager", IsVeteran = true };
                    case 103:
                        return new EmployeeRecord { Id = 103, Name = "hyra", Role = "Intern", IsVeteran = false };
                    default:
                        return new EmployeeRecord { Id = employeeId, Name = "uday", Role = "Other", IsVeteran = false };
                }
            }
        }


        public class PayrollProcessor
        {
            private readonly IEmployeeDataReader _dataReader;

            private static readonly Dictionary<int, decimal> BaseSalaries = new Dictionary<int, decimal>
        {
            {101, 65000m},
            {102, 120000m},
            {103, 30000m}
        };

            public PayrollProcessor(IEmployeeDataReader dataReader)
            {
                _dataReader = dataReader;
            }

            public decimal CalculateTotalCompensation(int employeeId)
            {
                var record = _dataReader.GetEmployeeRecord(employeeId);

                decimal baseSalary = BaseSalaries.ContainsKey(employeeId) ? BaseSalaries[employeeId] : 0m;
                decimal bonus = 0m;

                //decimal bonus = record switch
                //{
                //    { Role: "Manager", IsVeteran: true } => 10000m,
                //    { Role: "Manager", IsVeteran: false } => 5000m,           // new version of pattern matching Am not able to do these due to old version in my vs code ///
                //    { Role: "Developer" } => 2000m,
                //    { Role: "Intern" } => 500m,
                //    _ => 0m
                //};


                switch (record.Role)
                {
                    case "Manager":
                        bonus = record.IsVeteran ? 10000m : 5000m;
                        break;
                    case "Developer":
                        bonus = 2000m;
                        break;
                    case "Intern":
                        bonus = 500m;
                        break;
                    default:
                        bonus = 0m;
                        break;
                }

                return baseSalary + bonus;
            }

            public void ProcessPayroll(int employeeId)
            {
                decimal totalComp = CalculateTotalCompensation(employeeId);
                Console.WriteLine($"Employee {employeeId} Total Compensation: {totalComp:C}");
            }
        }
    }
}
