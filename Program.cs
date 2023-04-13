using CAImportWorkflow;
using CAImportWorkflow.Data;
using CAImportWorkflow.LDAP;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");


//builder.Services.AddCors(options =>
//{
// options.AddPolicy(name: "MyAllowSpecificOrigins",
//   builder =>
//   {
//   builder.WithOrigins("http://outlook.com",
//   "http://www.outlook.com",
//   "https://outlook.office365.com");
//   });
//});

builder.Services.AddIdentity<User, IdentityRole>().AddRoles<IdentityRole>().AddUserManager<LdapUserManager<User>>()
.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


//builder.Services.AddControllersWithViews();
//Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedRoles.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseExceptionHandler("/Error/500");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
name: "default",
pattern: "{controller=Account}/{action=Login}/{id?}");


app.Run();