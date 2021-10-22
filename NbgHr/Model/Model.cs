using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgHr.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmpolyeeAddress { get; set; }
        public DateTime Dob { get; set; }
        public bool MaritalStatus { get; set; }
        public int NumberOfChildren { get; set; }
        public Speciality Speciality { get; set; }

        public virtual Department BelongingDepartment { get; set; }

    }


    public enum Speciality
    {
        DEVELOPER, MANAGER, PRODUCTION
    }


    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

         public virtual List<Employee> Employees { get; set; }
    }



    public class HrDbContext:DbContext{

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public HrDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=nbgHr2021;Integrated Security=True");
        }

    }

}
