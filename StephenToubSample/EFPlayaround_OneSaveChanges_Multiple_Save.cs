//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace ConsoleApp
//{
//    public class Employee
//    {
//        public int EmployeeId { get; set; }
//        public string Name { get; set; }
//        public int DepartmentId { get; set; }
//        public Department Department { get; set; }
//        public EmployeeDetails EmployeeDetails { get; set; }
//    }

//    public class Department
//    {
//        public int DepartmentId { get; set; }
//        public string DepartmentName { get; set; }
//        public List<Employee> Employees { get; set; }
//    }

//    public class EmployeeDetails
//    {
//        public int EmployeeDetailsId { get; set; }
//        public string Address { get; set; }
//        public string PhoneNumber { get; set; }
//        public int EmployeeId { get; set; }
//        public Employee Employee { get; set; }
//    }

//    public class MyDbContext : DbContext
//    {
//        public DbSet<Employee> Employees { get; set; }
//        public DbSet<Department> Departments { get; set; }
//        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFPlayaround2;Trusted_Connection=True;");
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Employee>()
//                .HasOne(e => e.Department)
//                .WithMany(d => d.Employees)
//                .HasForeignKey(e => e.DepartmentId);

//            modelBuilder.Entity<Employee>()
//                .HasOne(e => e.EmployeeDetails)
//                .WithOne(ed => ed.Employee)
//                .HasForeignKey<EmployeeDetails>(ed => ed.EmployeeId);
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var db = new MyDbContext())
//            {
//                // Ensure database is created
//                db.Database.EnsureCreated();

//                // Add a department
//                var department = new Department { DepartmentName = "IT" };
//                //db.Departments.Add(department);

//                // Add an employee with details
//                var employee = new Employee
//                {
//                    Name = "John Doe",
//                    Department = department,
//                    EmployeeDetails = new EmployeeDetails
//                    {
//                        Address = "123 Main St",
//                        PhoneNumber = "555-1234"
//                    }
//                };
//                db.Employees.Add(employee);

//                // Save changes to the database
//                db.SaveChanges();

//                // Query and display data
//                var employees = db.Employees
//                    .Include(e => e.Department)
//                    .Include(e => e.EmployeeDetails);

//                foreach (var emp in employees)
//                {
//                    Console.WriteLine($"Employee: {emp.Name}, Department: {emp.Department.DepartmentName}, Address: {emp.EmployeeDetails.Address}");
//                }

//                Console.ReadLine();
//            }
//        }
//    }
//}
