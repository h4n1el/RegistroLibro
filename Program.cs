using RegistroLibros.Components;
using RegistroLibros.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroLibros.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    builder.Services.AddDbContext<LibrosDbContext>(options =>
    options.UseSqlite(builder.Configuration["ConStr"]));

    builder.Services.AddScoped<LibroServices>();
    
    builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    

    

builder.Services.AddScoped<LibroRepository2, LibroRepository>();

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
