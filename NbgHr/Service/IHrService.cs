using NbgHr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgHr.Service
{
    public interface IHrService
    {
        public Task<List<Employee>> GetEmployee();
        public Task<Employee> GetEmployee(int id);

        public Task<List<Department>> GetDepartment();
        public Task<Department> GetDepartmen(int id);

        public Task<Employee> CreateEmployee( Employee employee);
        public Task<Department> CreateDepartment(Department department);


        public Task<Employee> EditEmployee(int id, Employee employee);
        public Task<Department> EditDepartment(int id, Department department);

        public Task<bool> DeleteEmployee(int id);
        public Task<bool> DeleteDepartment(int id);

    }
}
