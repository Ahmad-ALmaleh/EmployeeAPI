using EmployeeApi.Models;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => EmployeeService.GetAll();
        [HttpGet("{Id:int}")]
        public ActionResult<Employee> GetEmployee(int Id)
        {
            var employee = EmployeeService.GetEmployee(Id);
            if (employee == null)
            {
                return NotFound();
            }
            else return employee;
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeService.Add(employee);
            return CreatedAtAction(nameof(Create), employee);
        }
         [HttpPut("{Id}")]
        //[HttpPut]
        public ActionResult Update(int Id,Employee employee)
        {
            if(Id != employee.Id)
                return BadRequest();
            var existingEmployee = EmployeeService.GetEmployee(Id);
            if(existingEmployee is null)
            {
                return NotFound();
            }
            EmployeeService.Update(employee);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            var employee = EmployeeService.GetEmployee(Id);
            if (employee == null) { return NotFound(); }
            EmployeeService.Delete(Id);
            return NoContent();
        }
    }
}
