using FreshVegCart.Api.Data;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services
    .AddOpenApi()
    .AddDbContext<DataContext>(options =>
        options.UseSqlServer(config.GetConnectionString("Default"))
            .UseSeeding((context, _) =>
            {
                if (context.Set<Product>().Any())
                {
                    return;
                }

                context.Set<Product>().AddRange(Product.GetSeedData());
                context.SaveChanges();
            })
            .UseAsyncSeeding(async (context, _, ct) =>
            {
                if (await context.Set<Product>().AnyAsync(cancellationToken: ct))
                {
                    return;
                }

                context.Set<Product>().AddRange(Product.GetSeedData());
                await context.SaveChangesAsync(cancellationToken: ct);
            }));

services.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
