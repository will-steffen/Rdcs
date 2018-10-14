using Rdcs.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MyAPI.DomainModel.Entities;

namespace MyAPI.DomainModel
{
    public class ApplicationContext : RdcsContext
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<User> User { get; set; }
    }
}
