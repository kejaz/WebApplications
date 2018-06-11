using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVCRazor.Models
{
    public class EmployeeDB : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
    }
}