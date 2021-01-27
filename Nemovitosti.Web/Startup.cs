using Castle.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nemovitosti.CompositionRoot;
using Nemovitosti.CompositionRoot.Aop;
using Nemovitosti.ServiceLayer.Implementation;
using Nemovitosti.ServiceLayer.Interface;
using Nemovitosti.Web.Mappers;
using Nemovitosti.Web.Mappers.Implementation;
using System.Configuration;

namespace Nemovitosti.Web
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
            var stringSettings = new ConnectionStringSettings("Connection", Configuration.GetConnectionString("ConnectionStringLocal"));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSession();
            services.AddSharedData(stringSettings);
            //Mimo Core se to dělalo v Global.asax, tedka Mapper doregistruju tady 
            services.AddSingleton<IMapperWeb, MapperWeb>();

            //Aby fungovalo AOP - loggingAspects
            services.AddSingleton(new ProxyGenerator());
            services.AddScoped<IInterceptor, LoggingAspect>();
            services.AddProxiedScoped<IPozemekService, PozemekService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
