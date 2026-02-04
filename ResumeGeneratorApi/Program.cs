using Microsoft.EntityFrameworkCore;
using ResumeGeneratorApi.Data;
using ResumeGeneratorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add secrets
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.
builder.Services.AddControllers();

// OpenAPI (Swagger) - https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// EF Core + PostgreSql
builder.Services.AddDbContext<ResumeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Services
builder.Services.AddHealthChecks().AddDbContextCheck<ResumeDbContext>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
