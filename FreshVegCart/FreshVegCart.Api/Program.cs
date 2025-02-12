using FreshVegCart.Api.Data;
using FreshVegCart.Api.Endpoints;
using FreshVegCart.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

var connectionString = config.GetConnectionString("Default") ?? string.Empty;

services
    .AddOpenApi()
    .RegisterDbContext(connectionString)
    .RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.RegisterApiEndpoints();

app.Run();
