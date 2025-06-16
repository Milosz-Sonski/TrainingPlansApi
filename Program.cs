using Microsoft.EntityFrameworkCore;
using TrainingPlansApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Rejestracja kontroler�w i widok�w
builder.Services.AddControllersWithViews();
// Konfiguracja po��czenia z baz� danych
builder.Services.AddDbContext<TrainingPlansContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

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
app.MapControllers(); // Obs�uga API dla /api/plans

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
