using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Multitrac.Application.DTOs;
using Multitrac.Application.Interfaces;
using Multitrac.Application.Mappings;
using Multitrac.Application.Services;
using Multitrac.Domain.Entities;
using Multitrac.Domain.Interfaces;
using Multitrac.Infrastructure.Data;
using Multitrac.Infrastructure.Repositories;
using Multitrac.Api.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new global::Microsoft.OpenApi.OpenApiInfo { Title = "Multitrac API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new global::Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = global::Microsoft.OpenApi.ParameterLocation.Header,
        Type = global::Microsoft.OpenApi.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(document => new global::Microsoft.OpenApi.OpenApiSecurityRequirement
    {
        [new global::Microsoft.OpenApi.OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
    });
});

// Configure Entity Framework
builder.Services.AddDbContext<BdmultitracContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.CommandTimeout(120)));

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Configure FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(MonedaDto).Assembly);

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? "MultitracSuperSecretKey2024!@#$%^&*()_+AbcdefGhiJKLmNoPqRsTuVwXyZ123");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"] ?? "MultitracAPI",
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"] ?? "MultitracWeb",
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// Configure Repository Pattern
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOperacionFleteSpRepository, OperacionFleteSpRepository>();

// Configure Auth Service
builder.Services.AddScoped<IAuthService, Multitrac.Api.Services.AuthService>();

// Configure Services - Catálogos simples
builder.Services.AddScoped<IService<MonedaDto, Moneda>, MonedaService>();
builder.Services.AddScoped<IService<BancoDto, Banco>, BancoService>();
builder.Services.AddScoped<IService<CargoDto, Cargo>, CargoService>();
builder.Services.AddScoped<IService<NivelEducativoDto, NivelEducativo>, NivelEducativoService>();
builder.Services.AddScoped<IService<AfpDto, Afp>, AfpService>();
builder.Services.AddScoped<IService<FlotaDto, Flota>, FlotaService>();
builder.Services.AddScoped<IService<ActividadDto, Actividad>, ActividadService>();
builder.Services.AddScoped<IService<TurnoDto, Turno>, TurnoService>();
builder.Services.AddScoped<IService<TipoPagoDto, TipoPago>, TipoPagoService>();
builder.Services.AddScoped<IService<TipoOcurrenciaDto, TipoOcurrencia>, TipoOcurrenciaService>();

// Configure Services - Operaciones
builder.Services.AddScoped<IService<OperacionDto, Operacion>, OperacionService>();
builder.Services.AddScoped<IService<OperacionGeneralDto, OperacionGeneral>, OperacionGeneralService>();
builder.Services.AddScoped<IService<OperacionGeneralEquipoDto, OperacionGeneralEquipo>, OperacionGeneralEquipoService>();
builder.Services.AddScoped<IService<OperacionFleteDto, OperacionFlete>, OperacionFleteService>();
builder.Services.AddScoped<OperacionFleteService>();
builder.Services.AddScoped<IService<OperacionInformeDto, OperacionInforme>, OperacionInformeService>();
builder.Services.AddScoped<IService<TipoCargaDto, TipoCarga>, TipoCargaService>();
builder.Services.AddScoped<IService<UnidadDto, Unidad>, UnidadService>();
builder.Services.AddScoped<IService<OperacionHorarioDto, OperacionHorario>, OperacionHorarioService>();
builder.Services.AddScoped<IService<OperacionTurnoDto, OperacionTurno>, OperacionTurnoService>();
builder.Services.AddScoped<IService<OperacionCargaDto, OperacionCarga>, OperacionCargaService>();
builder.Services.AddScoped<IService<OperacionTipoDto, OperacionTipo>, OperacionTipoService>();

// Configure Services - Personal
builder.Services.AddScoped<IService<PersonalDto, Multitrac.Domain.Entities.Personal>, PersonalService>();
builder.Services.AddScoped<IService<PersonalRecordDto, PersonalRecord>, PersonalRecordService>();
builder.Services.AddScoped<IService<PersonalCargoDto, PersonalCargo>, PersonalCargoService>();
builder.Services.AddScoped<IService<PersonalVacacionesDto, PersonalVacaciones>, PersonalVacacionesService>();
builder.Services.AddScoped<IService<ContratistaDto, Contratista>, ContratistaService>();
builder.Services.AddScoped<IService<PersonalEquipoDto, PersonalEquipo>, PersonalEquipoService>();
builder.Services.AddScoped<IService<PersonalEppDto, PersonalEpp>, PersonalEppService>();
builder.Services.AddScoped<IService<PersonalEppKardexDto, PersonalEppKardex>, PersonalEppKardexService>();
builder.Services.AddScoped<IService<PersonalVacacionesRegistroDto, PersonalVacacionesRegistro>, PersonalVacacionesRegistroService>();
builder.Services.AddScoped<IService<PersonalLicenciaConducirDto, PersonalLicenciaConducir>, PersonalLicenciaConducirService>();
builder.Services.AddScoped<IService<PersonalSuenoDto, PersonalSueno>, PersonalSuenoService>();

// Configure Services - Equipos
builder.Services.AddScoped<IEquipoService, EquipoService>();
builder.Services.AddScoped<IService<EquipoDto, Equipo>, EquipoService>();
builder.Services.AddScoped<IService<EquipoCombustibleDto, EquipoCombustible>, EquipoCombustibleService>();
builder.Services.AddScoped<IService<EquipoKilometrajeDto, EquipoKilometraje>, EquipoKilometrajeService>();
builder.Services.AddScoped<IService<EquipoMantenimientoDto, EquipoMantenimiento>, EquipoMantenimientoService>();
builder.Services.AddScoped<IService<EquipoMantenimientoDetalleDto, EquipoMantenimientoDetalle>, EquipoMantenimientoDetalleService>();
builder.Services.AddScoped<IService<EquipoDocumentoTractoDto, EquipoDocumentoTracto>, EquipoDocumentoTractoService>();
builder.Services.AddScoped<IService<EquipoDocumentoCarretaDto, EquipoDocumentoCarreta>, EquipoDocumentoCarretaService>();

// Configure Services - Cliente/Proveedor/Area/Empresa/Convoy
builder.Services.AddScoped<IService<ClienteDto, Cliente>, ClienteService>();
builder.Services.AddScoped<IService<ProveedorDto, Proveedor>, ProveedorService>();
builder.Services.AddScoped<IService<AreaDto, Area>, AreaService>();
builder.Services.AddScoped<IService<TipoDocumentoDto, TipoDocumento>, TipoDocumentoService>();
builder.Services.AddScoped<IService<EmpresaDto, Empresa>, EmpresaService>();
builder.Services.AddScoped<IService<ConvoyDto, Convoy>, ConvoyService>();

// Configure Services - Contabilidad
builder.Services.AddScoped<IService<BaucherCajaDto, BaucherCaja>, BaucherCajaService>();
builder.Services.AddScoped<IService<BaucherEgresoDto, BaucherEgreso>, BaucherEgresoService>();

var app = builder.Build();

// Global exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Starting Multitrac API");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
