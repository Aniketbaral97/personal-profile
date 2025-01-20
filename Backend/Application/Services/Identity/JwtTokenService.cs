using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Identity;

public class JwtTokenService
{
    private readonly JwtConfig _jwtConfig;

    public JwtTokenService(JwtConfig jwtConfig)
    {
        _jwtConfig = jwtConfig;
    }

    public string GenerateJSONWebToken(UserDto user, List<Claim> claims)
    {
        List<Claim> userClaims = new();
        var securityKey = GetSymmetricSecurityKey();
        var tokenExpiresAt = GetTokenExpiresDate();
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        if (claims.Count > 0)
        {
            userClaims.AddRange(claims);
        }
        var name = user.FirstName!;
        if (!string.IsNullOrEmpty(user.MiddleName))
        {
            name = $"{name} {user.MiddleName}";
        }
        if (!string.IsNullOrEmpty(user.LastName))
        {
            name = $"{name} {user.LastName}";
        }
        userClaims.Add(new Claim(ClaimTypes.Name, user.UserName!));
        userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        userClaims.Add(new Claim("CreatedDate", user.CreatedAt.ToString()));
        userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName!));
        userClaims.Add(new Claim("TokenExpireDateTime", tokenExpiresAt.ToString()));
        userClaims.Add(new Claim("FullName", name));
        var token = new JwtSecurityToken(_jwtConfig.Issuer,
          null,
          userClaims,
          expires: tokenExpiresAt,
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }



    public DateTime GetTokenExpiresDate()
    {
        return DateTime.UtcNow.AddHours(_jwtConfig.ExpiresInHour);
    }

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
    }
}
