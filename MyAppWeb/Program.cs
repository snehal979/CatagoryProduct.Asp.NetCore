using DataAccese.Data;
using DataAccese.InfraStructure.IRespositity;
using DataAccese.InfraStructure.Respositity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUnityOfWork, UbityOfWork>();
builder.Services.AddControllersWithViews();
//Database
builder.Services.AddDbContext<AppDbContext>(op => {
    op.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
    });

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
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
