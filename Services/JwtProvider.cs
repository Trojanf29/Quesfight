using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using QuesFight.Services;

namespace QuesFight.Providers
{
    public class JwtProvider
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secret;
        private readonly int _lifetime;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
            _secret = options.Value.Secret;
            _lifetime = options.Value.LifetimeInMinutes;
        }

        public string GenerateAccessToken(string identifier, string role)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, identifier),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_secret));
            JwtSecurityToken token = new(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(_lifetime),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipleFromExpiredToken(string token)
        {
            TokenValidationParameters parameters = new() {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
                ValidAudience = _audience,
                ValidIssuer = _issuer,
            };

            ClaimsPrincipal principal = new JwtSecurityTokenHandler()
                .ValidateToken(token, parameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtToken ||
                !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return null;
            return principal;
        }
    }
}
