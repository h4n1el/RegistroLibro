using ResgistroEstudiante.Components;
using RegistrosEstudiante.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

  

var ConStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<Contexto>(op => op.UseSqlServer(ConStr));


builder.Services.AddScoped<EstudianteServices>();

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
