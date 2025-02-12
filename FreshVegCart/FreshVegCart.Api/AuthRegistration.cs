namespace FreshVegCart.Api;

public static class AuthRegistration
{
    public static IServiceCollection RegisterAuthentication(this IServiceCollection services, JwtConfig jwtConfig)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var secretKey = jwtConfig.SecretKey;
                var issuer = jwtConfig.Issuer;

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
