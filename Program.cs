using BlazorAppWithIdentity.Components;
using BlazorAppWithIdentity.Contexts;
using BlazorAppWithIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddGitHub(options =>
    {
        options.ClientId = builder.Configuration["GitHub:ApiKey"]!;
        options.ClientSecret = builder.Configuration["GitHub:ApiSecret"]!;
    })
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services
    .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
