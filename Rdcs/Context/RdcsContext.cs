using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Rdcs.Context
{
    public class RdcsContext : DbContext
    {
        private static string connectionString;
        private static bool useInMemory;

        public RdcsContext(DbContextOptions<RdcsContext> options) : base(options) { }
        public RdcsContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
                useInMemory = configuration.GetValue<bool>("ConnectionStrings:UseInMemory");
            }
            if (useInMemory)
            {
                optionsBuilder.UseInMemoryDatabase("in_memory_name");
            }
            else
            {
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
