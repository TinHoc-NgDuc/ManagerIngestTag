using ManagerIngest.Infrastructure.Datatable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerIngest.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
