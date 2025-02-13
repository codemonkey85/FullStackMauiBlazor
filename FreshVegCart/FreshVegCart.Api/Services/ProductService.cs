using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Api.Services;

public class ProductService(DataContext dataContext) : ServiceBase(dataContext)
{
    public async Task<ProductDto[]> GetProducts() => await DataContext.Products
            .AsNoTracking()
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Unit = p.Unit
            })
            .ToArrayAsync();
}
