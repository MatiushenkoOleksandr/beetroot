using Microsoft.EntityFrameworkCore;
using Service.Repository.Entities;
using Servis.Repository.Entities;

namespace Service.Repo
{
    public class ServiseDbContext : DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ReservationEntity> Reservations{ get; set; }

        public ServiseDbContext(DbContextOptions<ServiseDbContext> options) : base(options) { }
    }
}