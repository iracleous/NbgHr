using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgHr.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmpolyeeAddress { get; set; }
        public DateTime Dob { get; set; }
        public bool MaritalStatus { get; set; }
        public int NumberOfChildren { get; set; }
        public Speciality Speciality { get; set; }
        [ForeignKey("BelongingDepartmentId")]
        public virtual Department BelongingDepartment { get; set; }
       
    }


    public enum Speciality
    {
        DEVELOPER, MANAGER, PRODUCTION
    }


    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [InverseProperty("BelongingDepartment")]
        public virtual List<Employee> Employees { get; set; }
    
    }



   

}
