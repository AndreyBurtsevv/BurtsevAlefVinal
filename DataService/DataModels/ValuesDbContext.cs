using DataService.Configurators;
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ValueConfigurator());
        }
    }
}
