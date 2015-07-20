using System;
using System.Data;
using EmployeeService.Entity;
using EmployeeService.Factory;


namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {

        public Employee GetEmployee(int id)
        {
            var empFact = new EmployeeFactory();

            return empFact.GetFromDb(id);
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee == null)
                return;
            var empFact = employee.GetFactory();

            empFact.Persist(employee);
        }
    }
}
