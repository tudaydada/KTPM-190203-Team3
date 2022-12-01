using WebRaoVat;
using Microsoft.EntityFrameworkCore;
using WebRaoVat.Data;
using WebRaoVat.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(60*60);
    options.Cookie.IsEssential = true;
});

var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.
services.AddControllersWithViews();
services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("DatabaseName")));


services.AddTransient<ICategoryService, CategoryService>();
services.AddTransient<ICommentService, CommentService>();
services.AddTransient<IPostService, PostService>();
services.AddTransient<IAccountService, AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();
//app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
