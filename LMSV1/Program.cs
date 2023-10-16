using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;
using LMSV1.Models;
using System;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<LMSV1Context>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("LMSV1Context") ?? throw new InvalidOperationException("Connection string 'LMSV1Context' not found.")));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection") ?? throw new InvalidOperationException("Connection string 'LocalConnection' not found.")));
options.UseSqlServer(builder.Configuration.GetConnectionString("deadcoderslmsv") ?? throw new InvalidOperationException("Connection string 'LocalConnection' not found.")));


builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<LMSV1Context>();

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

app.MapRazorPages();

app.Run();
