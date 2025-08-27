using Api_SIDCOP.API.Extensions;
using Api_Sistema_Reportes.API.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Crear y registrar el DbContextFactory como singleton
var dbContextFactory = new SIDCOP_Backend.DataAccess.DbContextFactory(builder.Configuration);
builder.Services.AddSingleton(dbContextFactory);

// Obtener la cadena de conexión inicial
var initialConnectionString = dbContextFactory.GetConnectionString();

// Configurar el contexto de base de datos con la cadena de conexión inicial
builder.Services.AddDbContext<BDD_SIDCOPContext>(options => 
{
    options.UseSqlServer(initialConnectionString);
});

// Configurar SIDCOP_Context para usar el factory
SIDCOP_Backend.DataAccess.SIDCOP_Context.SetFactory(dbContextFactory);

// Establecer también la cadena de conexión estática como respaldo
SIDCOP_Backend.DataAccess.SIDCOP_Context.BuildConnectionString(initialConnectionString);

builder.Services.AddHttpContextAccessor();
// Configurar DataAccess para usar el DbContextFactory
builder.Services.DataAccess(provider => 
{
    var factory = provider.GetRequiredService<SIDCOP_Backend.DataAccess.DbContextFactory>();
    return factory.GetConnectionString();
});
builder.Services.BusinessLogic();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(typeof(MappingProfileExtensions));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutter", policy =>
    {
        policy.SetIsOriginAllowed(origin => true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .WithExposedHeaders("X-API-KEY");

    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    // Configuraci?n de ApiKey
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Ingrese la ApiKey en el encabezado 'X-Api-Key'",
        Type = SecuritySchemeType.ApiKey,
        Name = "X-Api-Key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowFlutter");
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
