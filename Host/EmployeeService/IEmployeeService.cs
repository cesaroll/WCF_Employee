using System.ServiceModel;
using EmployeeService.Entity;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        EmployeeInfo GetEmployee(EmployeeRequest request);

        [OperationContract]
        void SaveEmployee(EmployeeInfo employeeInfo);
    }
}
