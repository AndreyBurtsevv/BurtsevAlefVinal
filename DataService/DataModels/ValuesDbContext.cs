using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.DataModels
{
    public class ValuesDbContext : DbContext
    {
        public DbSet<DBValue> Values { get; set; }

        public ValuesDbContext(DbContextOptions<ValuesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            if (!Values.Any())
            {
                Values.Add(new DBValue { Name = "Bilain", Description = "091" });
                Values.Add(new DBValue { Name = "MTS", Description = "068" });
                SaveChanges();
            }
        }
    }
}
