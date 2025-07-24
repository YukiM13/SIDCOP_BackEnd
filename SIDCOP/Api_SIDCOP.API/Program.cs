

using Api_SIDCOP.API.Extensions;
using Api_Sistema_Reportes.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.DataAccess.Context;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SIDCOPConn");

builder.Services.AddDbContext<BDD_SIDCOPContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.DataAccess(connectionString);
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
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
