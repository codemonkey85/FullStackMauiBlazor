namespace FreshVegCart.Api;

public class JwtConfig
{
    public const string ConfigSectionName = "Jwt";

    public string SecretKey { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public int ExpirationInMinutes { get; set; }
}
