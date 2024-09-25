using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task RemoveEmployeeFromDepartment(int employeeId, int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId);
        Task<Department> GetDepartment(int departmentId);
        Task<Employee> GetEmployeeById(int id);

    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }


        public Task<Employee> CreateEmployee(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        public Task RemoveEmployeeFromDepartment(int employeeId, int departmentId)
        {
            return _employeeRepository.RemoveEmployeeFromDepartment(employeeId, departmentId);
        }

        public Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            return _employeeRepository.GetEmployeesByDepartment(departmentId);
        }

        public Task<Department> GetDepartment(int departmentId)
        {
            return _employeeRepository.GetDepartment(departmentId);
        }
    }

}
