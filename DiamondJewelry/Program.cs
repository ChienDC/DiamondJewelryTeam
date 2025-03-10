using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DiamondJewelry.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session expiration time (30 minutes)
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<JewelryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<JewelryDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // Default login path
    options.AccessDeniedPath = "/Auth/AccessDenied"; // 403 page, user logged in but not an admin
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache(); // Required for session
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services.CreateScope();
using (var scope1 = app.Services.CreateScope())
{
    var services = scope1.ServiceProvider;
    var context = services.GetRequiredService<JewelryDbContext>();

    try
    {
        DbInitializer.Seed(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding data: {ex.Message}");
    }
}

// Create a new role
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
// Create a new user
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

if (!await roleManager.RoleExistsAsync("Admin"))
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));
}

var adminUser = new IdentityUser
{
    UserName = "diamond@example.com",
    Email = "diamond@example.com",
    EmailConfirmed = true
};

if (await userManager.FindByEmailAsync(adminUser.Email) == null)
{
    var result = await userManager.CreateAsync(adminUser, "@Admin123");
    if (result.Succeeded)
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

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

app.UseAuthentication();
app.UseAuthorization();

// Route for Admin area
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// Default route for non-area controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
