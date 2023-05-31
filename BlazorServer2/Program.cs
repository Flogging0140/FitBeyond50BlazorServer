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
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

// detailed errrors
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
});

// add cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("smtp-relay.sendinblue.com",
                                "https://api.brevo.com",
                                "https://smtp-relay.sendinblue.com",
                                "https://fitbeyond50.ca/",
                                "https://api.brevo.com/v3/smtp/email");
        });
});

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

// email api service
builder.Services.AddTransient<BrevoEmailApiHelper>();

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

//
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
