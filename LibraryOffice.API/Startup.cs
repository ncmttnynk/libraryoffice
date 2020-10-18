using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRestService.ControllerFactory;
using LibraryOffice.API.ControllerFactory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryOffice.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            var cnnStr = Configuration.GetConnectionString ("pays-cnn");

            services.AddEntityFrameworkNpgsql ().AddDbContext<LibraryOfficeDbContext> (builder => {
                builder.UseNpgsql (cnnStr);
            });

            var mvcBuilder = services.AddMvc ();
            mvcBuilder.AddMvcOptions (o => o.Conventions.Add (new GenericRestControllerNameConvention ()));
            mvcBuilder.ConfigureApplicationPartManager (c => {
                c.FeatureProviders.Add (new GenericRestControllerFeatureProvider ());
            });

            services.RegisterLibraryOfficeRepos ();
            services.RegisterLibraryOfficeServices ();
            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}