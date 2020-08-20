using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.DataModels
{
    public class ValuesDbContext : DbContext
    {
        public DbSet<Value> Values { get; set; }

        public ValuesDbContext(DbContextOptions<ValuesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            if (!Values.Any())
            {
                Values.Add(new Value { Name = "Bilain", Description = "091" });
                Values.Add(new Value { Name = "MTS", Description = "068" });
                SaveChanges();
            }
        }
    }
}
