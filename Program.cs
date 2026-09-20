using RegistroLibros.Components;
using RegistroLibros.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroLibros.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<BibliotecaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddScoped<LibroRepository>();
builder.Services.AddScoped<LibroServices>();

builder.Services.AddScoped<EstudianteRepository>();
builder.Services.AddScoped<EstudianteServices>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
