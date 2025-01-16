using AspNetCoreRateLimit;
using LibraryManagement.Application;
using LibraryManagement.Application.Common.Security;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure;
using LibraryManagement.Infrastructure.Services;
using LibraryManagement.Infrastructure.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prometheus;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryManagementAPI", Version = "v1" });

    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Add rate limiting services
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

// Register Dependency Injection containers
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

// Register http clients for OpenLibrary services
builder.Services.AddHttpClient<IISBNDBBookService, ISBNDBBookService>(client =>
{
    client.BaseAddress = new Uri("https://api2.isbndb.com");
    client.DefaultRequestHeaders.Add("User-Agent", "insomnia/5.12.4"); // HTTP client for testing APIs
    client.DefaultRequestHeaders.Add("Authorization", builder.Configuration["ISBNDBAPIKey:APIKey"]);
    client.DefaultRequestHeaders.Add("Accept", "*/*");
});

builder.Services.AddHttpClient<IOpenLibraryBookService, OpenLibraryBookService>(client =>
{
    client.DefaultRequestHeaders.Add("Contact-Email", "jmo@live.dk");
});

builder.Services.AddHttpClient<IOpenLibraryEditionService, OpenLibraryEditionService>(client =>
{
    client.DefaultRequestHeaders.Add("Contact-Email", "jmo@live.dk");
});

// Register the UnitOfWork service
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registering JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", jwtOptions =>
    {
        jwtOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SECRET_KEY"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "https://localhost:7222",
            ValidAudience = "https://localhost:7222",
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryManagementAPI v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

// Enable rate limiting
app.UseIpRateLimiting();

// Enable Prometheus metrics
app.UseHttpMetrics();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Map the Prometheus metrics endpoint
app.MapMetrics();

app.Run();
