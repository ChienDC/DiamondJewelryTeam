using DiamondJewelry.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lấy Connection String từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
  .AddEntityFrameworkStores<AspnetCoreStarterMvcContext>()
  .AddDefaultTokenProviders();


// Thêm DbContext
builder.Services.AddDbContext<AspnetCoreStarterMvcContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
  options.LoginPath = "/Auth/Login"; // Account/Login <- default
  options.AccessDeniedPath = "/Auth/AccessDenied"; // Trang 403, đăng nhập rồi nhưng không phải admin hoặc ...
  options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services.CreateScope();
// tạo mới role
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
// tạo mới user
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
  var result = await userManager.CreateAsync(adminUser, "Admin@123");
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

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
  name: "default",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
