using AuthorizationLayer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationLayer.JWT;

public class JWTGenerator
{
    public const string JWT_Security_Key = "TakrorlashJudaHamMaxfiyQiyinParolYozildi";
    public string GenerateToken(AuthModel authModel)
    {
        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(10);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_Security_Key);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, authModel.Username),
            new Claim(ClaimTypes.Role, authModel.Role),
        });
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256);
        var securityTokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials,
            IssuedAt = DateTime.Now
        };
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        return jwtSecurityTokenHandler.WriteToken(securityToken);
    }
}
