using SGE.UI.Components;
using SGE.Repositorio;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Utiles;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Servicios;


SistemaSQlite.Inicializar();

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddTransient<UsuarioValidador>();
builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddTransient<GeneradorHash>();
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddTransient<ServicioActualizacionEstado>();
builder.Services.AddTransient<EspecificacionCambioEstado>();
builder.Services.AddTransient<ExpedienteValidador>();


builder.Services.AddTransient<CasoDeUsoRegistrar>();
builder.Services.AddTransient<CasoDeUsoListarUsuarios>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoModificarUsuario>();
builder.Services.AddTransient<CasoDeUsoObtenerUsuario>();




//builder.Services.AddTransient<CasoDeUsoLogin>();

//builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
//builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoListarExpedientes>();
//builder.Services.AddTransient<CasoDeUsoConsultaExpediente>();

builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
//builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
//builder.Services.AddTransient<CasoDeUsoConsultaTramitesEtiqueta>();
builder.Services.AddTransient<CasoDeUsoListarTramites>();

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