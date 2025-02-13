namespace FreshVegCart.Shared.Dtos;

public record ApiResult(bool IsSuccess, string? ResultMessage)
{
    public static ApiResult Success(string resultMessage) => new(true, resultMessage);

    public static ApiResult Fail(string resultMessage) => new(false, resultMessage);
}

public record ApiResult<T>(bool IsSuccess, string? ResultMessage, T? Data)
{
    public static ApiResult<T> Success(T data, string resultMessage) => new(true, resultMessage, data);

    public static ApiResult<T> Fail(string resultMessage) => new(false, resultMessage, default);
}
