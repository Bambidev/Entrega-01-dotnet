using SGE.UI.Components;
using SGE.Repositorio;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Utiles;


SistemaSQlite.Inicializar();

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddTransient<UsuarioValidador>();
builder.Services.AddTransient<GeneradorHash>();


builder.Services.AddTransient<CasoDeUsoRegistrar>();
builder.Services.AddTransient<CasoDeUsoListarUsuarios>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();


//builder.Services.AddTransient<CasoDeUsoLogin>();

//builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
//builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
//builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();
//builder.Services.AddTransient<CasoDeUsoConsultaExpediente>();

//builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
//builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
//builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
//builder.Services.AddTransient<CasoDeUsoConsultaTramitesEtiqueta>();

builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpedienteSQlite>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramiteSQlite>();
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuariosSQlite>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();