using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPITestDemo.MockEmployeData;

namespace RESTAPITestDemo.Controllers
{
    
    [ApiController]
 
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployes()
        {
            return Ok(_employee.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployes(Guid id)
        {
            var employee = _employee.GetEmployeeby_Guid(id);
            if (employee != null)
            {
                return Ok(employee);

            }
            else {

                return NotFound($"Employee is not found with Guid {id}");
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult InsertEmployee(models.Employee employee)
        {
            _employee.Insert_Employe(employee);
            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host+HttpContext.Request.Path+"/"+employee.Employee_Id, employee);
            

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteeEmployes(Guid id)
        {
            var employee = _employee.GetEmployeeby_Guid(id);
            if (employee != null)
            {
                _employee.Delete_Employee(employee);
                return Ok(employee);

            }
            else
            {

                return NotFound($"Employee is not found with Guid: {id}");
            }
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateEmployes(Guid id, models.Employee employee)
        {
            var exstingemployee = _employee.GetEmployeeby_Guid(id);
            if (exstingemployee != null)
            {
                employee.Employee_Id = exstingemployee.Employee_Id;
                 exstingemployee = _employee.Update_Employee(employee);
                return Ok(exstingemployee);

            }
            else
            {

                return NotFound($"Employee is not found with Guid: {id}");
            }
        }

    }
}
