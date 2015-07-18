using System;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract(Namespace = "http://cesartech.com/2015/07/17/Employee")]
    public class Employee
    {
        [DataMember(Order = 1, Name = "ID")]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }
        
        [DataMember(Order = 3)]
        public string Gender { get; set; }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth { get; set; }

    }
}
