using Blazored.LocalStorage;
using InventoryWeb;
using InventoryWeb.Data;
using InventoryWeb.Repository.IInterface;
using InventoryWeb.Repository.Services;
using InventoryWeb.Services.AuthServices;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped(spa => new HttpClient { BaseAddress = new Uri("http://localhost:5012/") });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBrand, BrandService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
