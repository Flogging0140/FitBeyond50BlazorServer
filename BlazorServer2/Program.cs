using BlazorServer2;
using BlazorServer2.Areas.Identity;
using BlazorServer2.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

string? emailPassword = System.Environment.GetEnvironmentVariable("SMTP_PASSWORD");

string? sqlServerPassword = System.Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD");
if (string.IsNullOrEmpty(sqlServerPassword))
    throw new Exception("Was not able to find ENV variable");

connectionString = connectionString.Replace("PASSWORD_HERE", sqlServerPassword);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

// email

builder.Services.AddTransient<MailKitSender>();
builder.Services.Configure<MailKitEmailSenderOptions>(options =>
{
    options.Host_Address = "smtp-relay.sendinblue.com";
    options.Host_Port = 587;
    options.Host_Username = "paulsonhanel@gmail.com";
    options.Host_Password = emailPassword; 
    options.Sender_EMail = "bhanel@gmail.com";
    options.Sender_Name = "FitBeyond50.ca";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
