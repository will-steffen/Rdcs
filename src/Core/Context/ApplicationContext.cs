using Microsoft.EntityFrameworkCore;
using Rdcs.Models;

namespace Rdcs.Core.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public ApplicationContext() : base() { }

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
