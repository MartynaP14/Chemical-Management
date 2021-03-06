using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Chemical_Management.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Chemical_ManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chemical_ManagementContext") ?? throw new InvalidOperationException("Connection string 'Chemical_ManagementContext' not found.")));

///builder.Services.AddDbContext<LabUserContext>(options =>
    ///options.UseSqlServer(builder.Configuration.GetConnectionString("Mat_mag") ));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/login";
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); //needs to be ahead of authorization for cookie creations
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
