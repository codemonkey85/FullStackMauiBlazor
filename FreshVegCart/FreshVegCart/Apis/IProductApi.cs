using FreshVegCart.Shared.Library.Dtos;
using Refit;

namespace FreshVegCart.Apis;

public interface IProductApi
{
    [Get("/api/products")]
    Task<ProductDto[]> GetProducts();
}
