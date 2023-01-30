using CrudApi.DAL;
using CrudApi.Interface;
using CrudApi.Model;

namespace CrudApi.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeMaster
    {
        private EmployeeDbContext _dbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeeMaster AddEmployee(EmployeeMaster employee)
        {
            _dbContext.employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployeeMaster(EmployeeMaster employee)
        {
            _dbContext.employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public EmployeeMaster EditEmployee(EmployeeMaster employee)
        {
            var emp = _dbContext.employees.Find(employee.Id);
            if (emp != null)
            {
                if (emp.Name != employee.Name) { emp.Name = employee.Name; }
                if (emp.Department != employee.Department) { emp.Department = employee.Department; }
                _dbContext.employees.Update(emp);
                _dbContext.SaveChanges();
            }
            return employee;
        }

        public EmployeeMaster GetEmployeeMaster(int id)
        {
            var employee = _dbContext.employees.Find(id);
            return employee;
        }

        public List<EmployeeMaster> GetEmployeeMasterList()
        {
            return _dbContext.employees.ToList();
        }
    }
}
