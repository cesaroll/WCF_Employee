
using System;
using EmployeeService.Factory;

namespace EmployeeService.Entity
{
    public class EmployeeFullTime : Employee
    {  

        public Decimal AnnualSalary { get; set; }

        public override EmployeeFactory GetFactory()
        {
            return new EmployeeFullTimeFactory();
        }
    }
}