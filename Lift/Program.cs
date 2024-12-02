using ActualLab.Fusion.UI;
using ActualLab.Fusion;
using Lift.Data;
using Lift.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ActualLab.Fusion.Extensions;
using Lift.Infrastructure;
using ActualLab.Fusion.Blazor;

namespace Lift
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            var connectionString = builder.Configuration.GetConnectionString("ElevatorDb");
            builder.Services.AddDbContext<ElevatorDbContext>(options =>
                options.UseNpgsql(connectionString));


            var fusion = builder.Services.AddFusion();
            fusion.AddBlazor();
            fusion.AddFusionTime();
            fusion.AddService<ElevatorService>();
            fusion.AddService<CounterService>();

            builder.Services.AddScoped<ElevatorService>();


            builder.Services.AddHttpContextAccessor();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
