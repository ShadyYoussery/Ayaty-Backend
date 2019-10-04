using Ayaty.Context.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ayaty.Setup.Bll.Business;
using Ayaty.Setup.Bll.Interfaces;
using Shared.Bll.Business;
using Shared.Bll.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace Setup
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
            services.AddDbContext<AyatyContext>(option =>
                option.UseSqlServer("Data Source=DESKTOP-GU88C36;Initial Catalog=Ayaty;Integrated Security=True"));
            services.AddCors();

            services.AddScoped<IMapping, MappingManagement>();
            services.AddScoped<ICountry, CountryManagement>();
            services.AddScoped<IState, StateManagement>();
            services.AddScoped<ICity, CityManagement>();
            services.AddScoped<IMessageResponse, MessageResponseManagement>();
            services.AddScoped<IAyatyHelper, AyatyHelperManagement>();
            services.AddScoped<IPaging, PagingManagement>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Ayaty Setup API",
                    Description = "Ayaty Setup API by system admin",
                    TermsOfService = "https://example.com/terms",
                    Contact = new Contact
                    {
                        Name = "Itlws",
                        Email = string.Empty,
                        Url = "https://itlws.com/info",
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
            app.UseCors(t => t.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
