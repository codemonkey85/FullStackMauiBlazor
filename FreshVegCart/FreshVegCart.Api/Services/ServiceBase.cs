using FreshVegCart.Api.Data;

namespace FreshVegCart.Api.Services;

public class ServiceBase(DataContext dataContext)
{
    internal readonly DataContext DataContext = dataContext;
}
