using FreshVegCart.Api.Services;

namespace FreshVegCart.Api.Endpoints;

public static class Product
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder apiGroup)
    {
        var group = apiGroup
            .MapGroup("/products")
            .WithTags("Products");

        group.MapGet(string.Empty, GetProducts);

        return apiGroup;
    }

    private static async Task<IResult> GetProducts(ProductService productService)
    {
        var products = await productService.GetProducts();
        return Results.Ok(products);
    }
}
