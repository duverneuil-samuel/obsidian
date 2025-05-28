// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddRazorPages();

using Microsoft.EntityFrameworkCore;
using Obsidian.Models; 
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Default");

builder.Services.AddRazorPages();

// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
