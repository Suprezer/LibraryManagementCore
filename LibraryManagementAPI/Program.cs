using AspNetCoreRateLimit;
using LibraryManagement.Application;
using LibraryManagement.Application.IService;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure;
using LibraryManagement.Infrastructure.Services;
using LibraryManagement.Infrastructure.UnitOfWork;
using Prometheus;

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

app.UseAuthorization();

app.MapControllers();

// Map the Prometheus metrics endpoint
app.MapMetrics();

app.Run();
