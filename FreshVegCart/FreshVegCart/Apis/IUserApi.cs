﻿using FreshVegCart.Shared.Library.Dtos;
using Refit;

namespace FreshVegCart.Apis;

[Headers("Authorization: Bearer ")]
public interface IUserApi
{
    [Post("/api/users/addresses")]
    Task<ApiResult> SaveAddress(AddressDto dto);

    [Get("/api/users/addresses/{userId}")]
    Task<ApiResult> GetAddresses(int userId);

    [Post("/api/users/change-password")]
    Task<ApiResult> ChangePassword(ChangePasswordDto dto);
}
