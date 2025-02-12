namespace FreshVegCart.Api.Endpoints;

public static class Registration
{
    public static IEndpointRouteBuilder RegisterApiEndpoints(this IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup("/api");

        apiGroup
            .MapAuthEndpoints()
            .MapProductEndpoints()
            .MapOrderEndpoints()
            .MapUserEndpoints();

        return app;
    }
}
