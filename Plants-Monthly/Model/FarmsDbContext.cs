using Microsoft.EntityFrameworkCore;


namespace Plants_Monthly.Model
{
    public class FarmsDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected readonly IConfiguration Configuration;

        public FarmsDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("FarmsConnection"));
        }
    }
}

