using Microsoft.EntityFrameworkCore;
using TrainBackendApi.Models;

namespace TrainBackendApi.Repository
{
    public class TrainDbConntext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Railway> Railways { get; set; }

        private readonly IConfiguration configuration;
        public TrainDbConntext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionstring = configuration["Database:ConnectionString"];
            options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
        }
    }
}
