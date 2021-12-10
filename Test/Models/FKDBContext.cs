using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class FKDBContext : DbContext
    {
        public FKDBContext(DbContextOptions<FKDBContext> options) : base(options)    //Constructor
        {

        }
        
        public DbSet<Department> Departments { get; set; } //Here Department is Model class & Departments is the table name that will be created in sql
        public DbSet<Employee> Employees { get; set; }

    }
}
