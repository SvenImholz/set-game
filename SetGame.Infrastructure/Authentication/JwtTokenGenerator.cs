using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using SetGame.Application.Common.Interfaces.Authentication;
using SetGame.Application.Common.Services;
using SetGame.Domain.PlayerAggregate;

using JwtRegisteredClaimNames=
    Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SetGame.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    readonly IDateTimeProvider _dateTimeProvider;
    readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(
        IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Player player)
    {
        var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
        SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, player.Id.ToString()!),
            new Claim(JwtRegisteredClaimNames.GivenName, player.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, player.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var securityToken = new JwtSecurityToken(
        _jwtSettings.Issuer,
        _jwtSettings.Audience,
        expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
        claims: claims,
        signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}