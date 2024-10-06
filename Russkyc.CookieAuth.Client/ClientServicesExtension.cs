using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Russkyc.CookieAuth.Core;

namespace Russkyc.CookieAuth.Client;

public static class ClientServicesExtension
{
    public static void AddCookieAuth(
        this IServiceCollection services,
        string userEndpoint = Endpoints.CookieEndpoint,
        Action<AuthorizationOptions>? authorizationOptions = null)
    {
        if (authorizationOptions is null)
        {
            services.AddAuthorizationCore();
        }
        else
        {
            services.AddAuthorizationCore(authorizationOptions);
        }

        services.AddScoped<AuthenticationStateProvider>(
            serviceProvider => new CookieAuthenticationStateProvider(
                serviceProvider.GetRequiredService<HttpClient>(),
                userEndpoint));
    }
}