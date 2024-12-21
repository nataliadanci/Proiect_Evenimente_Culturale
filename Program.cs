using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_MP1.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Evenimente");
    options.Conventions.AllowAnonymousToPage("/Evenimente/Index");
    options.Conventions.AllowAnonymousToPage("/Evenimente/Details");
    options.Conventions.AuthorizeFolder("/Users", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/EventPlanners", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Registrations");
});
builder.Services.AddDbContext<Proiect_MP1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_MP1Context") ?? throw new InvalidOperationException("Connection string 'Proiect_MP1Context' not found.")));

builder.Services.AddDbContext<EventIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_MP1Context") ?? 
    throw new InvalidOperationException("Connection string 'Proiect_MP1Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EventIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
