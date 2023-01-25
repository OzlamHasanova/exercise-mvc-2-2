using DataAcces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); 


builder.Services.AddDbContext<AppDbContext>(opt =>

    opt.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

var app = builder.Build();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );

app.UseStaticFiles();
app.Run();
