using Microsoft.EntityFrameworkCore;
using ReizenData.Models;
using ReizenData.Repositories;
using ReizenServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReizenContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReizenConnection")));
builder.Services.AddTransient<WerelddeelService>();
builder.Services.AddTransient<IWerelddeelRepository, SQLWerelddeelRepository>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
