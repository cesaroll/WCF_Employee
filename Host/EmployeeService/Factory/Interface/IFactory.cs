using EmployeeService.Entity.Interface;

namespace EmployeeService.Factory.Interface
{
    public interface IFactory
    {
        IEntity GetFromDb(int id);
        void Persist(IEntity entity);
    }
}