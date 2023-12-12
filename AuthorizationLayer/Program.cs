global using Microsoft.EntityFrameworkCore;
using AuthorizationLayer;
using AuthorizationLayer.JWT;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomJwtLayer();
builder.Services.AddSingleton<JWTGenerator>();
string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
string DB_PASSWORD = Environment.GetEnvironmentVariable("SA_PASSWORD");

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    var con = $"Data source={DB_HOST};" +
                    $"Initial Catalog={DB_NAME};" +
                    $"User ID=SA;Password={DB_PASSWORD};" +
                    $"TrustServerCertificate=True;";
    options.UseSqlServer(con);
});

// Define Swagger generation options and add Bearer token authentication
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWT Auth Sample",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer jhfdkj.jkdsakjdsa.jkdsajk\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
