using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RangeManagementSystem.Data;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Web.Services.Register;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext, RangeManagementSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
       .AddEntityFrameworkStores<RangeManagementSystemDbContext>()
       .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Application services
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<ApplicationRole>>();
builder.Services.AddTransient<IRegisterService, RegisterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed data on application startup
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider.GetRequiredService<RangeManagementSystemDbContext>();
if (app.Environment.IsDevelopment())
{
    services.Database.Migrate();
    new ApplicationDbContextSeeder().SeedAsync(services, scope.ServiceProvider).GetAwaiter().GetResult();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
