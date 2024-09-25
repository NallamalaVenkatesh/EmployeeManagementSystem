namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<DepartmentEmployee> DepartmentEmployees { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<DepartmentEmployee> DepartmentEmployees { get; set; }
    }

    public class DepartmentEmployee
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }

}
