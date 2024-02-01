using WebApp_Cinepolis.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configure Session
builder.Services.AddSession(); 

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CinepolisContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
var app = builder.Build();

//Se cree la base de datos por la migración
/*
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<CinepolisContext>();
    context.Database.Migrate();
}
*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mantenimiento}/{action=Cines}/{id?}");

app.Run();
