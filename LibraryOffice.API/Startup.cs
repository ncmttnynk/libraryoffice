using GenericRestService.ControllerFactory;
using LibraryOffice.API.ControllerFactory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryOffice.API
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
            var cnnStr = Configuration.GetConnectionString("mssql-cnn");

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<LibraryOfficeDbContext>(builder => { builder.UseSqlServer(cnnStr); });

            var mvcBuilder = services.AddMvc();
            mvcBuilder.AddMvcOptions(o => o.Conventions.Add(new GenericRestControllerNameConvention()));
            mvcBuilder.ConfigureApplicationPartManager(c =>
            {
                c.FeatureProviders.Add(new GenericRestControllerFeatureProvider());
            });

            services.AddSwaggerGen();

            services.RegisterLibraryOfficeRepos();
            services.RegisterLibraryOfficeServices();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}