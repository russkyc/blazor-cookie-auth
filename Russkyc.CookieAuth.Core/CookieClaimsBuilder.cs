using System.Security.Claims;

namespace Russkyc.CookieAuth.Core;

public class CookieClaimsBuilder
{
    private readonly List<Claim> _claims = [];

    public CookieClaimsBuilder WithClaims(string key, string value, string? valueType = null, string? issuer = null)
    {
        var claim = new Claim(key, value, valueType, issuer);
        _claims.Add(claim);
        return this;
    }

    public ClaimsPrincipal ToClaimsPrincipal()
    {
        var claimsIdentity = new ClaimsIdentity(_claims, AuthenticationScheme.CookieAuth);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        return claimsPrincipal;
    }
}