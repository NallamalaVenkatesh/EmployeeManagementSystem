using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeManagementContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentEmployee>()
                .HasKey(de => new { de.EmployeeId, de.DepartmentId });

            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Employee)
                .WithMany(e => e.DepartmentEmployees)
                .HasForeignKey(de => de.EmployeeId);
        }
    }

}
