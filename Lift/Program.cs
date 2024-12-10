using ActualLab.Fusion;
using ActualLab.Fusion.Blazor;
using ActualLab.Fusion.EntityFramework;
using ActualLab.Fusion.EntityFramework.Npgsql;
using ActualLab.Fusion.Extensions;
using Lift.Data;
using Lift.Infrastructure;
using Lift.Services;
using Microsoft.EntityFrameworkCore;

namespace Lift
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddDbContextServices<ElevatorDbContext>(db =>
            {
                db.AddOperations(operations =>
                {
                    operations.ConfigureOperationLogReader(_ => new()
                    {
                        CheckPeriod = TimeSpan.FromSeconds(5),
                    });
                    operations.ConfigureEventLogReader(_ => new()
                    {
                        CheckPeriod = TimeSpan.FromSeconds(5),
                    });
                    operations.AddNpgsqlOperationLogWatcher();
                });
                db.Services.AddTransientDbContextFactory<ElevatorDbContext>((c, db) =>
                {
                    db.UseNpgsql(builder.Configuration.GetConnectionString("ElevatorDb"), npgsql =>
                    {
                        npgsql.EnableRetryOnFailure(0);
                    });
                    db.UseNpgsqlHintFormatter();
                });
            });

            var fusion = builder.Services.AddFusion();
            fusion.AddBlazor();
            fusion.AddFusionTime();
            fusion.AddService<ElevatorService>();
            fusion.AddOperationReprocessor();

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
