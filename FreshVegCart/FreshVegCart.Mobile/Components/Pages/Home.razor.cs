using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Mobile.Components.Pages;
public partial class Home
{
    private ProductDto[] products = [];

    protected override async Task OnInitializedAsync()
    {
        products = await ProductApi.GetProducts();
    }
}
