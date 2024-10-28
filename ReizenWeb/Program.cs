using Microsoft.EntityFrameworkCore;
using ReizenData.Models;
using ReizenData.Repositories;
using ReizenServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReizenContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReizenConnection")));
builder.Services.AddTransient<WerelddeelService>();
builder.Services.AddTransient<LandService>();
builder.Services.AddTransient<BestemmingService>();
builder.Services.AddTransient<ReisService>();
builder.Services.AddTransient<IWerelddeelRepository, SQLWerelddeelRepository>();
builder.Services.AddTransient<ILandRepository, SQLLandRepository>();
builder.Services.AddTransient<IBestemmingRepository, SQLBestemmingRepository>();
builder.Services.AddTransient<IReisRepository, SQLReisRepository>();
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
name: "BestemmingReizen",
pattern: "Reis/BestemmingReizen/{code:alpha:maxlength(5)}",
defaults: new { controller = "Reis", action = "BestemmingReizen" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//Exception prep voor alles, lees oefening goed, Boekingen
