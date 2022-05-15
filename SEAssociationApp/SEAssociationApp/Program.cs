using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SEAssociationApp.Data;
using SEProjectApp.Abstractions.Repository;
using SEProjectApp.DataAccess;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("AssociationContextConnection") ?? throw new InvalidOperationException("Connection string 'AssociationContextConnection' not found.");

//builder.Services.AddDbContext<AssociationContext>(options =>
//    options.UseSqlServer(connectionString));;

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AssociationContext>();builder.Services.AddDbContext<AssociationContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDb")));

//Add services to the container.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.Configure<IdentityOptions>(options =>
{
// Password settings
options.Password.RequireDigit = true;
options.Password.RequiredLength = 8;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequireUppercase = true;
options.Password.RequireLowercase = false;
options.Password.RequiredUniqueChars = 6;

// Lockout settings
options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
});




//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var connectionStringIdentity = builder.Configuration.GetConnectionString("IdentityConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionStringIdentity));

//builder.Services.AddDbContext<AssociationContext>(options =>
//    options.UseSqlServer(connectionString));


//builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
//builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
//builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
//builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>(); 





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});


app.Run();