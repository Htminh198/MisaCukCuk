using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCukCuk_Data
{
    public class MisaCukCukDbContextFactory : IDesignTimeDbContextFactory<MisaCukCukDbContext>
    {
        public MisaCukCukDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<MisaCukCukDbContext>();
            optionBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=MisaCukCuk;Integrated Security=True");
            return new MisaCukCukDbContext(optionBuilder.Options);
        }
    }
}
