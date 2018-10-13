using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Rdcs.Models;

namespace Rdcs.Core.Context
{
    public class ApplicationContext : DbContext
    {
        private static string connectionString;
        private static bool useInMemory;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public ApplicationContext() : base() { }

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

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
