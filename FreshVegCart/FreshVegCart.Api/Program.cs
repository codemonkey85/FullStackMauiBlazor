var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

var connectionString = config.GetConnectionString("Default") ?? string.Empty;

services
    .AddOpenApi()
    .RegisterDbContext(connectionString)
    .RegisterServices()
    .RegisterAuthentication(config);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.RegisterApiEndpoints();

app.Run();
