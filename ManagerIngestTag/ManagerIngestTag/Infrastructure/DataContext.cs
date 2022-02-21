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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HistoryIngest> HistoryIngests { get; set; }
        public DbSet<IngestDetail> IngestDetails { get; set; }
        public DbSet<IngestTag> IngestTags { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProductionUnit> ProductionUnits { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StatusIngest> StatusIngests { get; set; }
        public DbSet<TicketIngest> TicketIngests { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
