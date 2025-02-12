namespace FreshVegCart.Api.Data;

public static class Registration
{
    public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString).SeedProductData());

    private static DbContextOptionsBuilder SeedProductData(this DbContextOptionsBuilder options) => options
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
        });
}
