using Microsoft.EntityFrameworkCore;
using VMS_API.Interfaces;
using VMS_API.Models;
using VMS_API.Services;

namespace VMS_API
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration)
        { 
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VMSDBContext>(options =>
            {
                options.UseSqlServer("Server=ASHOK;initial catalog=VMSDB;Trusted_Connection=True;");
            });
            services.AddCors(options =>
            {
                options.AddPolicy("ServiceAPIPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            
            services.AddTransient<IDashboard, DashboardService>();
            services.AddTransient<IMaster, MasterServices>();
            services.AddControllers();
            services.AddEndpointsApiExplorer(); 
            services.AddSwaggerGen();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("ServiceAPIPolicy");
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
