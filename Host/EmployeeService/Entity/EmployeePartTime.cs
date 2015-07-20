using System;
using EmployeeService.Factory;

namespace EmployeeService.Entity
{
    public class EmployeePartTime : Employee
    {
        public Decimal HourlyPay { get; set; }
        public int HoursWorked { get; set; }


        public override EmployeeFactory GetFactory()
        {
            return new EmployeePartTimeFactory();
        }
    }
}