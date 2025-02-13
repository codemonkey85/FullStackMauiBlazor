using FreshVegCart.Shared.Dtos;
using Refit;

namespace FreshVegCart.Mobile.Apis;

public interface IProductApi
{
    [Get("/api/products")]
    Task<ProductDto[]> GetProducts();
}
