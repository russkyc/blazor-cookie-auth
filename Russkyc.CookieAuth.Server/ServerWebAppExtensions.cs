using System.Security.Claims;
using Russkyc.CookieAuth.Core;

namespace Russkyc.CookieAuth.Server;

public static class ServerWebAppExtensions
{
    public static void MapCookieEndpoint(this WebApplication webApplication, string endpoint = Endpoints.CookieEndpoint)
    {
        webApplication.MapGet(endpoint,
            (ClaimsPrincipal user) => user.Claims.ToDictionary(x => x.Type, x => x.Value)
        );
    }
}