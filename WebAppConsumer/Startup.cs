using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Net.Http;
using WebAppConsumer.Services;

namespace WebAppConsumer
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }
      public IConfiguration Configuration { get; }
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddScoped(x => new HttpClient() { BaseAddress = new Uri(Configuration.GetSection("HostGraphQL").Value) });
         services.AddScoped<CarService>();
         services.AddControllersWithViews();
      }
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
         var supportedCultures = new[]
         {
               new CultureInfo("pt-BR")
         };
         app.UseRequestLocalization(new RequestLocalizationOptions
         {
            DefaultRequestCulture = new RequestCulture("pt-BR"),            
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
         });
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
