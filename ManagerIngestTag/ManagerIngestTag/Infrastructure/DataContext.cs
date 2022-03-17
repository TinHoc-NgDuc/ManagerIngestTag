using ManagerIngest.Infrastructure.Datatable;
using Microsoft.EntityFrameworkCore;
using ManagerIngestTag.Infrastructure.Datatable;

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
        public DbSet<ProgramShow> ProgramShows { get; set; }
        public DbSet<StatusIngest> StatusIngests { get; set; }
        public DbSet<TicketIngest> TicketIngests { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
