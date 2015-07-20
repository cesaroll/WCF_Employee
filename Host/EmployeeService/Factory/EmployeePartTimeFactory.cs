using System.Data.SqlClient;
using EmployeeService.Entity;

namespace EmployeeService.Factory
{
    public class EmployeePartTimeFactory : EmployeeFactory
    {
        public override void PersistAddExtraParameters(SqlParameterCollection parameters, Employee employee)
        {
            var emp = employee as EmployeePartTime;

            if (emp != null)
            {
                parameters.AddWithValue("@HourlyPay", emp.HourlyPay);
                parameters.AddWithValue("@HoursWorked", emp.HoursWorked);
            }

        }
    }
}