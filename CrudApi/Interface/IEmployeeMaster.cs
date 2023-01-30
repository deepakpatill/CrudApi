using CrudApi.Model;

namespace CrudApi.Interface
{
    public interface IEmployeeMaster
    {
        List<EmployeeMaster> GetEmployeeMasterList();
        EmployeeMaster GetEmployeeMaster(int id);
        EmployeeMaster AddEmployee(EmployeeMaster employee);
        void DeleteEmployeeMaster(EmployeeMaster employee);
        EmployeeMaster EditEmployee(EmployeeMaster employee);
    }
}
