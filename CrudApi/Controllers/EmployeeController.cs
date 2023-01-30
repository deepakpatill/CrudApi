using CrudApi.DAL;
using CrudApi.Interface;
using CrudApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeMaster _employeeMaster;

        public EmployeeController(IEmployeeMaster employeeMaster)
        {
            _employeeMaster = employeeMaster;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeMaster.GetEmployeeMasterList());
        }

        [HttpGet("{id}", Name ="Get")]
        public IActionResult GetEmployee(int id) 
        {
            var employee = _employeeMaster.GetEmployeeMaster(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id: {id} was not found");
        }

        [HttpPost]
        public IActionResult GetEmployee(EmployeeMaster employee)
        {
            _employeeMaster.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeMaster.GetEmployeeMaster(id);
            if (employee != null)
            {
                _employeeMaster.DeleteEmployeeMaster(employee);
                return Ok();

            }
            return NotFound($"Employee with Id: {id} was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult EditEmployee(int id, [FromBody] EmployeeMaster employee)
        {
            var emp = _employeeMaster.GetEmployeeMaster(id);
            if (emp != null)
            {
                employee.Id = emp.Id;
                EmployeeMaster newData = _employeeMaster.EditEmployee(employee);
                var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path;
                return Ok();
            }
            return NotFound($"Employee with Id: {id} was not found");
        }
    }
}
