using Microsoft.EntityFrameworkCore;
using NbgHr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgHr.Service
{
    public class HrService : IHrService
    {
        private readonly HrDbContext hrDbContext;

        public HrService(HrDbContext hrDbContext)
        {
            this.hrDbContext = hrDbContext;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            hrDbContext.Departments.Add(department);
            await hrDbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            hrDbContext.Employees.Add(employee);
            await hrDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            Department department = hrDbContext.Departments.Find(id);
            if (department == null) return false;
            hrDbContext.Departments.Remove(department);
            await hrDbContext.SaveChangesAsync();
            return true;
        }

        public  async Task<bool> DeleteEmployee(int id)
        {
            Employee employee = hrDbContext.Employees.Find(id);
            if (employee == null) return false;
            hrDbContext.Employees.Remove(employee);
            await hrDbContext.SaveChangesAsync();
            return true;
        }

        public   async Task<Department> EditDepartment(int id, Department department)
        {
            Department departmentFromDb = hrDbContext.Departments.Find(id);
            if (departmentFromDb == null) return null;
            departmentFromDb.Location = department.Location;
            departmentFromDb.Name = department.Name;
            await hrDbContext.SaveChangesAsync();
            return departmentFromDb;
        }

        public async Task<Employee> EditEmployee(int id, Employee employee)
        {
            Employee employeeFromDb = hrDbContext.Employees.Find(id);
            if (employeeFromDb == null) return null;

            employeeFromDb.EmployeeName = employee.EmployeeName;
            employeeFromDb.EmpolyeeAddress = employee.EmpolyeeAddress;
            employeeFromDb.Dob = employee.Dob;
            employeeFromDb.MaritalStatus = employee.MaritalStatus;
            employeeFromDb.NumberOfChildren = employee.NumberOfChildren;
            employeeFromDb.Speciality = employee.Speciality;

            await hrDbContext.SaveChangesAsync();
            return employeeFromDb;
        }

        public async Task<Department> GetDepartmen(int id)
        {
            //      return await hrDbContext.Departments.Where(dpt => dpt.Id == id).FirstOrDefaultAsync();
            return await hrDbContext.Departments.FindAsync(id);
        }

        public async Task<List<Department>> GetDepartment()
        {
            return await hrDbContext.Departments.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployee()
        {
            return await hrDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await hrDbContext.Employees.FindAsync(id);
        }
    }
}
