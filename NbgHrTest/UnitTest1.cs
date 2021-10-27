using Microsoft.EntityFrameworkCore;
using NbgHr.Model;
using System;
using System.Linq;
using Xunit;

namespace NbgHrTest
{
    public class DepartmentTest
    {
        [Fact]
        public void SaveAsync_Deparment()
        {

            var department = new Department() { Name = "HR", Location = "Z" };
            var helper = new TestHelper();
            var hrDbContext = helper.GetHrDbContext();

            hrDbContext.Departments.Add(department);
            hrDbContext.SaveChangesAsync().GetAwaiter();

            var result = hrDbContext.Departments
                .Where(dpt => dpt.Location.Equals("Z"))
                .FirstOrDefaultAsync()
                .Result;


            Assert.NotNull(result);
        }
    }
}
