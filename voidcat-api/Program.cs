using Microsoft.EntityFrameworkCore;
using voidcat_api.Data;
using voidcat_api.Services;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------
// Configuration
// ----------------------------------------
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// ----------------------------------------
// Logging
// ----------------------------------------
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// ----------------------------------------
// Services
// -------------------------------------    ---

// HTTP Client for OpenAI
builder.Services.AddHttpClient<IChatGptService, ChatGptService>(client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/");
});

// Entity Framework - SQL Server
builder.Services.AddDbContext<TarotDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("VoidCat"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(20),
                errorNumbersToAdd: null);
        });
});

// Memory Cache
builder.Services.AddMemoryCache();

// Dependency Injection
builder.Services.AddScoped<ITarotRepository, TarotRepository>();
builder.Services.AddScoped<ITarotService, TarotService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IChatGptService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var config = sp.GetRequiredService<IConfiguration>();
    return new ChatGptService(
        httpClient,
        config["OpenAI:ApiKey"]!,
        config["OpenAI:AssistantId"]!);
});

// Controllers
builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "https://voidcat.co.uk")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// ----------------------------------------
// Build & Pipeline
// ----------------------------------------

var app = builder.Build();

// Swagger (enable in dev only — or remove the if-check to have it always)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");
app.UseAuthorization();

// Routing
app.MapControllers();

app.Run();
