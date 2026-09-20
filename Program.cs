using RegistroLibros.Components;
using RegistroLibros.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroLibros.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    builder.Services.AddDbContextFactory<LibrosDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConStr"]));

    builder.Services.AddScoped<LibroServices>();
    builder.Services.AddScoped<EstudianteServices>();
    
    builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    

    

builder.Services.AddScoped<LibroRepository>();


var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
