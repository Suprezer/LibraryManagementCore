using AspNetCoreRateLimit;
using LibraryManagement.Application;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure;
using LibraryManagement.Infrastructure.Services;
using LibraryManagement.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
