using Ayaty.Context.Models;
using Ayaty.Clinic.Management.Bll.Business;
using Ayaty.Clinic.Management.Bll.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ayaty.Shared.Bll.Business;
using Ayaty.Shared.Bll.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace Ayaty.Clinic.Management
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IMapping, MappingManagement>();
            services.AddScoped<IClinic, ClinicManagement>();
            services.AddScoped<IMessageResponse, MessageResponseManagement>();

            services.AddDbContext<AyatyContext>(option =>
                option.UseSqlServer("Data Source=DESKTOP-GU88C36;Initial Catalog=Ayaty;Integrated Security=True"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",new Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "https://example.com/terms",
                    Contact = new Contact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer",
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
