using Microsoft.Extensions.Options;
using ClickMe.Application.Services;
using ClickMe.Application.DatabaseSettings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ClickActionDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ClickActionDatabaseSettings)));

builder.Services.AddSingleton<IClickActionDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ClickActionDatabaseSettings>>().Value);

builder.Services.AddSingleton<IClickActionService, ClickActionService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
