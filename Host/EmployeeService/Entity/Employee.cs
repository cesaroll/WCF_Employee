using System;
using System.Runtime.Serialization;
using EmployeeService.Entity.Interface;
using EmployeeService.Factory;
using EmployeeService.Factory.Interface;

namespace EmployeeService.Entity
{
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
