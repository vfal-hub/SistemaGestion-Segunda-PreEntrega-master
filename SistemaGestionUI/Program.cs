using SistemaGestionUI.Components;
using SistemaGestionUI.ClientServices;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<ProductosService>();
builder.Services.AddTransient<UsuariosService>();
builder.Services.AddTransient<ProductosVendidosService>();
builder.Services.AddTransient<VentasService>();

builder.Services.AddHttpClient<UsuariosService>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Usuarios/")            
    );

builder.Services.AddHttpClient<ProductosService>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Productos/")
    );

builder.Services.AddHttpClient<ProductosVendidosService>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/ProductosVendidos/")
    );

builder.Services.AddHttpClient<VentasService>(
    client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Ventas/")
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
