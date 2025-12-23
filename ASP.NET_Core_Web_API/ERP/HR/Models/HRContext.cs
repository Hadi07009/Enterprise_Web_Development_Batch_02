using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class HRContext:DbContext
    {
        public HRContext(DbContextOptions<HRContext> options):base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
    }
}
