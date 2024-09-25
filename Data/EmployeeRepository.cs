using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task RemoveEmployeeFromDepartment(int employeeId, int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId);
        Task<Department> GetDepartment(int departmentId);
        Task<Employee> GetEmployeeById(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementContext _context;

        public EmployeeRepository(EmployeeManagementContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


        public async Task RemoveEmployeeFromDepartment(int employeeId, int departmentId)
        {
            var departmentEmployee = await _context.DepartmentEmployees
                .FirstOrDefaultAsync(de => de.EmployeeId == employeeId && de.DepartmentId == departmentId);

            if (departmentEmployee != null)
            {
                _context.DepartmentEmployees.Remove(departmentEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees
                .Include(e => e.DepartmentEmployees)
                .ThenInclude(de => de.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }


        public async Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            return await _context.DepartmentEmployees
                .Where(de => de.DepartmentId == departmentId)
                .Select(de => de.Employee)
                .ToListAsync();
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }
    }

}
