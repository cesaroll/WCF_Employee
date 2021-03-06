﻿using System;
using System.Data;
using System.ServiceModel;
using EmployeeService.Entity;
using EmployeeService.Factory;


namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeeService : IEmployeeService
    {
        public EmployeeInfo GetEmployee(EmployeeRequest request)
        {
            Console.WriteLine("License key = " + request.LicenseKey);

            var empFact = new EmployeeFactory();

            var employee = empFact.GetFromDb(request.EmployeeId);

            var employeeInfo = EmployeeInfo.ConvertToEmployeeInfo(employee);

            return employeeInfo;
        }

        public void SaveEmployee(EmployeeInfo employeeInfo)
        {
            if (employeeInfo == null)
                return;

            var employee = (Employee) employeeInfo;

            var empFact = employee.GetFactory();

            empFact.Persist(employee);
        }
    }
}
