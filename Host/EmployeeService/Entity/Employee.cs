using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using EmployeeService.Entity.Interface;
using EmployeeService.Factory;
using EmployeeService.Factory.Interface;

namespace EmployeeService.Entity
{
    [MessageContract(IsWrapped = true, WrapperName = "EmployeeRequestObject", WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://MyCompany.com/Employee", ProtectionLevel = System.Net.Security.ProtectionLevel.None)]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://MyCompany.com/Employee")]
        public int EmployeeId { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName = "EmployeeInfoObject", WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeInfo
    {
        public EmployeeInfo()
        {
        }

        /*public EmployeeInfo(Employee employee)
        {
            if (employee == null)
                return;

            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Gender = employee.Gender;
            this.DOB = employee.DateOfBirth;
            this.Type = employee.Type;

            if (this.Type == EmployeeType.EmployeeFullTime)
            {
                this.AnnualSalary = ((EmployeeFullTime) employee).AnnualSalary;
            }
            else
            {
                this.HourlyPay = ((EmployeePartTime)employee).HourlyPay;
                this.HoursWorked = ((EmployeePartTime)employee).HoursWorked;
            }

        }*/

        public static EmployeeInfo ConvertToEmployeeInfo(Employee employee)
        {
            if (employee == null)
                return null;

            var employeeInfo = new EmployeeInfo()
            {
                Id = employee.Id,
                Name = employee.Name,
                Gender = employee.Gender,
                DOB = employee.DateOfBirth,
                Type = employee.Type
            };

            if (employeeInfo.Type == EmployeeType.EmployeeFullTime)
            {
                employeeInfo.AnnualSalary = ((EmployeeFullTime)employee).AnnualSalary;
            }
            else
            {
                employeeInfo.HourlyPay = ((EmployeePartTime)employee).HourlyPay;
                employeeInfo.HoursWorked = ((EmployeePartTime)employee).HoursWorked;
            }

            return employeeInfo;
        }


        public static explicit operator Employee(EmployeeInfo empInfo)
        {
            Employee emp = null;

            if (empInfo.Type == EmployeeType.EmployeeFullTime)
            {
                emp = new EmployeeFullTime()
                {
                    Id = empInfo.Id,
                    Name = empInfo.Name,
                    Gender = empInfo.Gender,
                    DateOfBirth = empInfo.DOB,
                    Type = empInfo.Type,
                    AnnualSalary = empInfo.AnnualSalary
                };
            }
            else
            {
                emp = new EmployeePartTime()
                {
                    Id = empInfo.Id,
                    Name = empInfo.Name,
                    Gender = empInfo.Gender,
                    DateOfBirth = empInfo.DOB,
                    Type = empInfo.Type,
                    HourlyPay = empInfo.HourlyPay,
                    HoursWorked = empInfo.HoursWorked
                };
                
            }

            return emp;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://MyCompany.com/Employee")]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://MyCompany.com/Employee")]
        public string Name { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://MyCompany.com/Employee")]
        public string Gender { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://MyCompany.com/Employee")]
        public DateTime DOB { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://MyCompany.com/Employee")]
        public EmployeeType Type { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://MyCompany.com/Employee")]
        public decimal AnnualSalary { get; set; }

        [MessageBodyMember(Order = 7, Namespace = "http://MyCompany.com/Employee")]
        public decimal HourlyPay { get; set; }

        [MessageBodyMember(Order = 8, Namespace = "http://MyCompany.com/Employee")]
        public int HoursWorked { get; set; }

    }

    [DataContract(Namespace = "http://cesartech.com/2015/07/17/Employee")]
    [KnownType(typeof(EmployeeFullTime))]
    [KnownType(typeof(EmployeePartTime))]
    public class Employee : IEntity
    {
        public virtual EmployeeFactory GetFactory()
        {
            return new EmployeeFactory();
        }
        

        [DataMember(Order = 1, Name = "ID")]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }
        
        [DataMember(Order = 3)]
        public string Gender { get; set; }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Order = 5)]
        public virtual EmployeeType Type { get; set; }

        [DataMember(Order = 6)]
        public string City { get; set; }
        
        IFactory IEntity.GetFactory()
        {
            return GetFactory();
        }

    }

    public enum EmployeeType
    {
        EmployeeFullTime = 1,
        EmployeePartTime = 2
    }
    
}
