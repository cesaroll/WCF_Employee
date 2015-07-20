using System.Data;
using System.Data.SqlClient;
using EmployeeService.Entity;
using EmployeeService.Util;

namespace EmployeeService.Factory
{
    public class EmployeeFullTimeFactory : EmployeeFactory
    {
        public override void PersistAddExtraParameters(SqlParameterCollection parameters, Employee employee)
        {
            var emp = employee as EmployeeFullTime;

            if (emp != null)
            {
                parameters.AddWithValue("@AnnualSalary", emp.AnnualSalary);
            }
            
        }
    }
}