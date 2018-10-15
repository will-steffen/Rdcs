using Rdcs.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MyAPI.DomainModel.Entities;
using MyAPI.DomainModel.Authorization;

namespace MyAPI.DomainModel
{
    public class ApplicationContext : RdcsContext
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Group> Group { get; set; }
        public DbSet<LinkGroupUser> LinkGroupUser { get; set; }
        public DbSet<LinkPermissionGroup> LinkPermissionGroup { get; set; }
        public DbSet<Permission> Permission { get; set; }
    }
}
