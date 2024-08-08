using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using proyectoFinal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GestorRecetaContext>(options =>
        options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("conexion")));

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
    pattern: "{controller=Recetums}/{action=Index}/{id?}");

string wwwroot = app.Environment.WebRootPath;
Rotativa.AspNetCore.RotativaConfiguration.Setup(wwwroot, "rotativa");

app.Run();
