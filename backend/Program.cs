using ClickMeApi.Services;
using ClickMeApi.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ClickActionDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ClickActionDatabaseSettings)));

builder.Services.AddSingleton<IClickActionDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ClickActionDatabaseSettings>>().Value);

builder.Services.AddSingleton<ClickActionService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp"); // Enable CORS using the policy

app.UseAuthorization();

app.MapControllers();

app.Run();
