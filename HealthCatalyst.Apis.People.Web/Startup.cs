using HealthCatalyst.Apis.People.Data.Infrastructure;
using HealthCatalyst.Apis.People.Data.Repositories;
using HealthCatalyst.Apis.People.Web.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCatalyst.Apis.People.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Configuration);

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // DI for data.
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PeopleDatabase")));
            services.AddScoped<IPersonRepository, PersonRepository>();

            // DI for web.
            services.AddScoped<IPersonV1Mapper, PersonV1Mapper>();

            // Execute database migrations. Note that I'm doing this to make it easy to run as a demo, but I would definitely NOT have this in production code.
            using (var context = new DatabaseContext())
            {
                context.Database.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
