using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Notes.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Notes.Application.JWT
{
    public class JwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenereateToken(User user)
        {
            Claim[] claims = [new("id", user.Id.ToString())];

            var signingCredentails = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials:  signingCredentails,
                expires: DateTime.UtcNow.AddHours(_options.ExpireHource));

            var jwtTokenValue = new  JwtSecurityTokenHandler().WriteToken(token);
            return jwtTokenValue;
        }
    }
}
