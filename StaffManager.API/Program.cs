using StaffManager.Infrastructure.DI;
using System.Reflection;
using StaffManager.Infrastructure;
using StaffManager.Domain;
using System.Text.Json.Serialization;

IConfiguration _configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var currentAssembly = Assembly.GetExecutingAssembly();
var referencedAssemblies = currentAssembly.GetReferencedAssemblies()
    .Select(Assembly.Load)
    .Where(a => a.FullName.Contains("StaffManager"));

var configuration = new ConfigurationDbContext
{
    Assemblies = referencedAssemblies.Union(new[] { currentAssembly }).ToList()
};

builder.Services.AddSingleton<IConfigurationDbContext>(configuration);

builder.Services.AddControllers();

builder.Services.AddLibs(configuration);

builder.Services.AddSqlServer(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDevOrigin");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }