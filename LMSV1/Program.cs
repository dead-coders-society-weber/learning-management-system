using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LMSV1.Data;
using Microsoft.AspNetCore.Identity;
using LMSV1.Models;
using System;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Stripe;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<LMSV1Context>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("LMSV1Context") ?? throw new InvalidOperationException("Connection string 'LMSV1Context' not found.")));
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection") ?? throw new InvalidOperationException("Connection string 'LocalConnection' not found.")));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("deadcoderslmsv") ?? throw new InvalidOperationException("Connection string 'deadcoderslmsv' not found.")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<LMSV1Context>();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure Stripe API key
StripeConfiguration.ApiKey = "sk_test_51O0ngzJeBZBvA5DPQpcHeERFrfM8ijTRBhnaeiTY6c0uwIYGRI7ZXptAfD9LSb7Wziy6x9oSwqL0LpjNbH5fxr5400FZivegwR";

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

// api endpoint to get unread notification for user
app.MapGet("/api/notifications/unread/{id}", async (int id, LMSV1Context db) =>
{
    var notifications = await db.Notifications
                                .Where(n => n.StudentID == id && !n.IsRead)
                                .Select(n => new {
                                    n.NotificationID,
                                    Event = n.Event.ToString(),
                                    Course = n.Assignment.Course.CourseName,
                                    Assignment = n.Assignment.Title
                                })
                                .ToListAsync();
    return Results.Ok(notifications);
}).RequireAuthorization();

// api endpoint to change notification when read
app.MapPost("/api/notifications/markasread/{notificationId}", async (int notificationId, LMSV1Context db, HttpContext http) =>
{
    var userId = http.User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the user id from the claims
    var notification = await db.Notifications.FirstOrDefaultAsync(n => n.NotificationID == notificationId);
    if (notification != null && notification.StudentID.ToString() == userId) // Make sure to check if the notification belongs to the user
    {
        notification.IsRead = true;
        await db.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
}).RequireAuthorization();

app.Run();
