using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgHr.Model
{ 




public class HrDbContext : DbContext
{

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
    {

    }


}

}