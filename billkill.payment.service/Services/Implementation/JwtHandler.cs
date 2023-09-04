using billkill.payment.service.DTO.HelperModels;
using billkill.payment.service.DTO.HelperModels.Jwt;
using billkill.payment.service.Extensions;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace billkill.payment.service.Services.Implementation
{
    public class JwtHandler: IJwtHandler
    {
        AppConfiguration config = new AppConfiguration();
        public JwtResponse CreateToken(UserClaims model)
        {
            var now = DateTime.Now;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.JWTSecret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                claims: new Claim[] {
                    new Claim(nameof(model.Tin), model.Tin.ToString()),
                    new Claim(nameof(model.Name), model.Name)
                },
                expires: DateTime.Now.AddHours(8),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            JwtResponse jwtresponse = new JwtResponse()
            {
                Token = tokenString,
                ExpiresAt = unixTimeSeconds
            };
            return jwtresponse;
        }
    }
}
