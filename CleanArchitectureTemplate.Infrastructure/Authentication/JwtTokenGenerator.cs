using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitectureTemplate.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using CleanArchitectureTemplate.Application.Common.Interfaces.Services;

namespace CleanArchitectureTemplate.Infrastructure.Authentication;

internal class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This-is-a-secret-gggggggg-key-long-uuuuu")),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new []
        {
            new Claim(JwtRegisteredClaimNames.Sub, $"{firstName} {lastName}"),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.ToList();
        
        var securityToken = new JwtSecurityToken(
            issuer: "CleanArchitectureTemplate",
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddMinutes(30),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}