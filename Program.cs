using LibraryManagement.Services;
using LibraryManagement.ActionFilter;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("LibraryManagerDatabase");
builder.Services.AddDbContext<ManagerContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddSession();

builder.Services.AddScoped<UserService, UserServiceImpl>();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(UserActionFilter));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
