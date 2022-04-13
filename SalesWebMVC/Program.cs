using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<SalesWebMvcContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("SalesWebMvcContext")));
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesWebMvcContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<SeedingService>();
builder.Services.AddTransient<SeedingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
else
{
    SeedData(app);
}


void SeedData( IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using ( var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedingService>();
        Console.WriteLine("Entrei >>>>>");
        service.Seed();
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

