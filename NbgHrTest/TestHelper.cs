using Microsoft.EntityFrameworkCore;
using NbgHr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgHrTest
{
    public class TestHelper
    {

        private readonly HrDbContext hrDbContext;


        public HrDbContext GetHrDbContext()
        {
            return hrDbContext;
        }

        public TestHelper()
        {

            var dbContextOptions = new DbContextOptionsBuilder<HrDbContext>()
                .UseInMemoryDatabase(databaseName: "HrDbInMemory")
                .Options;

            hrDbContext = new HrDbContext(dbContextOptions);
            hrDbContext.Database.EnsureDeleted();
            hrDbContext.Database.EnsureCreated();
        }

        public IEnumerable<Department> GetMockDepartments()
        {
            return new List<Department>()
            {
                { new Department(){ Id = 1, Name  = "HR", Location = "A"} },
                { new Department(){ Id = 2, Name = "Sales", Location = "B"} },
                { new Department(){ Id = 3, Name = "Production", Location = "C"} }
            };
        }
    }
}
