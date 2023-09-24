using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;
using LMSV1.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("LMSV1UserContext") ?? throw new InvalidOperationException("Connection string 'LMSV1UserContext' not found.");
builder.Services.AddDbContext<LMSV1UserContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LMSV1UserContext>();

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

app.UseAuthentication();
app.UseAuthorization();

// Seed Initializer
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LMSV1UserContext>();
    context.Database.EnsureCreated();
    SeedData.Initialize(context);
}
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    // Get the required services
//    var dbContext = services.GetRequiredService<LMSV1UserContext>();
//    var userManager = services.GetRequiredService<UserManager<User>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    _ = SeedData.InitializeAsync(dbContext, userManager, roleManager);
//}

app.MapRazorPages();

app.Run();
