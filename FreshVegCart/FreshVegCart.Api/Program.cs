var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

var jwtConfig = new JwtConfig();
config.GetSection(JwtConfig.ConfigSectionName).Bind(jwtConfig);

var connectionString = config.GetConnectionString("Default") ?? string.Empty;

services
    .AddSingleton(jwtConfig)
    .AddOpenApi()
    .RegisterDbContext(connectionString)
    .RegisterServices()
    .RegisterAuthentication(jwtConfig);

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
