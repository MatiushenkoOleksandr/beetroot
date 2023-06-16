using Microsoft.EntityFrameworkCore;
using Service.Logic;
using Service.Repo;
using Service.Repository;
using Service.Repository.Abstracts;
using Service.Repository.Entities;
using Servis.Repository.Entities;

namespace FinalProjectASP
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddDbContext<ServiseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddTransient<CarService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<ReservationService>();
            services.AddScoped<IRepository<Guid, CarEntity>, CarRepository>();
            services.AddScoped<IRepository<Guid, CustomerEntity>, CustomerRepository>();
            services.AddScoped<IRepository<Guid, ReservationEntity>, ReservationRepository>();
            services.AddAutoMapper(typeof(Startup));
           

        }
    }
}
