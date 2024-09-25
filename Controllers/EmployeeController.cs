using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            _logger.LogInformation("Logging Test");
            var createdEmployee = await _employeeService.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{employeeId}/departments/{departmentId}")]
        public async Task<IActionResult> RemoveEmployeeFromDepartment(int employeeId, int departmentId)
        {
            await _employeeService.RemoveEmployeeFromDepartment(employeeId, departmentId);
            return NoContent();
        }

        [HttpGet("departments/{departmentId}/employees")]
        public async Task<IActionResult> GetEmployeesByDepartment(int departmentId)
        {
            var employees = await _employeeService.GetEmployeesByDepartment(departmentId);
            return Ok(employees);
        }

        [HttpGet("departments/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _employeeService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
    }

}
