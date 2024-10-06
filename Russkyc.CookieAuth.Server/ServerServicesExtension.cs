using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Russkyc.CookieAuth.Core;

namespace Russkyc.CookieAuth.Server;

public static class ServerServicesExtension
{
    public static void AddServerCookieAuth(
        this IServiceCollection services,
        Action<AuthorizationOptions>? authorizationOptions = null,
        Action<CookieAuthenticationOptions>? cookieAuthOptions = null)
    {
        if (authorizationOptions is null)
        {
            services.AddAuthorization();
        }
        else
        {
            services.AddAuthorization(authorizationOptions);
        }

        if (cookieAuthOptions is null)
        {
            services.AddAuthentication()
                .AddCookie(AuthenticationScheme.CookieAuth);
        }
        else
        {
            services.AddAuthentication()
                .AddCookie(AuthenticationScheme.CookieAuth, cookieAuthOptions);
        }
    }

    public static void UseServerCookieAuth(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}