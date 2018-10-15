using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rdcs.Constants;
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
                .AddJsonFile(Constant.CONFIG_FILE_NAME)
                .Build();
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString(Constant.CONFIG_DEFAULT_CONNECION);
                useInMemory = configuration.GetValue<bool>(Constant.CONFIG_USE_IN_MEMORY_DB);
            }
            if (useInMemory)
            {
                optionsBuilder.UseInMemoryDatabase(Constant.MEMORY_DB_NAME);
            }
            else
            {
                optionsBuilder.UseMySql(configuration.GetConnectionString(Constant.CONFIG_DEFAULT_CONNECION));
            }
        }
    }
}
