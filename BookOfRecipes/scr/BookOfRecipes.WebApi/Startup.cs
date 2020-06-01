using System;
using System.Linq;
using AutoMapper;
using BookOfRecipes.BusinessLogic.Mapping;
using BookOfRecipes.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookOfRecipes.WebApi
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
            services.AddControllers();

            services.AddDbContext<BookOfRecipesContext>(options => 
                options.UseSqlite(Configuration.GetConnectionString("BookOfRecipes")));

            services.AddAutoMapper(typeof(RecipeVariationProfile));

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name.StartsWith("BookOfRecipes"))
                .ToArray());

            services.AddSwaggerDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Book of Recipes API";
                };
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book of Recipes API");
            });
        }
    }
}
