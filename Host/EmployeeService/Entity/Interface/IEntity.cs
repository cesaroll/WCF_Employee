using EmployeeService.Factory.Interface;

namespace EmployeeService.Entity.Interface
{
    public interface IEntity
    {
        IFactory GetFactory();
    }
}