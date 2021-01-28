using Microsoft.EntityFrameworkCore;
using MisaCukCuk_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Data
{
    public class MisaCukCukDbContext : DbContext
    {
        public MisaCukCukDbContext(DbContextOptions<MisaCukCukDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerGroup> CustomerGroup { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }

    }
}
