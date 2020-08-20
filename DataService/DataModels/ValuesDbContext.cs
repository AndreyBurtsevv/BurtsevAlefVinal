using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DataModels
{
    public class ValuesDbContext : DbContext
    {
        public DbSet<Value> Values { get; set; }

        public ValuesDbContext(DbContextOptions<ValuesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
