using Amazon.SQS;
using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Infrastructure.DBContext;
using TesteDAlessio.UI.WebApp.Helpers;
using TesteDAlessio.UI.WebApp.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<TesteDAlessioDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("TesteDAlessioDB")));

        var appSettingsSection = builder.Configuration.GetSection("ServiceConfiguration");
        builder.Services.AddAWSService<IAmazonSQS>();

        builder.Services.Configure<ServiceConfiguration>(appSettingsSection);
        builder.Services.AddTransient<IAWSSQSService, AWSSQSService>();
        builder.Services.AddTransient<IAWSSQSHelper, AWSSQSHelper>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Login}/{id?}");

        app.Run();
    }
}