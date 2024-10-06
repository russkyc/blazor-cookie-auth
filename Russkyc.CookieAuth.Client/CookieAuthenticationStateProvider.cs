using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Russkyc.CookieAuth.Core;

namespace Russkyc.CookieAuth.Client;

public class CookieAuthenticationStateProvider(HttpClient httpClient, string userEndpoint) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var userClaims = await httpClient.GetFromJsonAsync<Dictionary<string, string>>(userEndpoint);
        var claims = userClaims!
            .Select(item => new Claim(item.Key, item.Value))
            .ToList();

        var identity = new ClaimsIdentity(claims, claims.Any() ? AuthenticationScheme.CookieAuth : string.Empty);
        var claimsPrincipal = new ClaimsPrincipal(identity);
        var authenticationState = new AuthenticationState(claimsPrincipal);

        NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        return authenticationState;
    }
}