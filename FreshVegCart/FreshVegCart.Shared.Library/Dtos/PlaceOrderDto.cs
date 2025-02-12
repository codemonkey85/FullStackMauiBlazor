namespace FreshVegCart.Shared.Library.Dtos;

public record PlaceOrderDto(int UserAddressId, string Address, string AddressName, OrderItemSaveDto[] Items);
