namespace FreshVegCart.Api;

public static class AuthRegistration
{
    public static IServiceCollection RegisterAuthentication(this IServiceCollection services, ConfigurationManager config)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var secretKey = config.GetValue<string>("Jwt:SecretKey") ?? string.Empty;
                var issuer = config.GetValue<string>("Jwt:Issuer");

                var securityKey = Encoding.UTF8.GetBytes(secretKey);
                var symmetricKey = new SymmetricSecurityKey(securityKey);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidateIssuer = true,
                    IssuerSigningKey = symmetricKey,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false
                };
            });

        services
            .AddAuthorization();

        return services;
    }
}
