using billkill.manager.backend.DTO.HelperModels.Jwt;
using billkill.manager.backend.Extensions;
using billkill.manager.backend.Models;
using billkill.manager.backend.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace billkill.manager.backend.Services.Implementation
{
    public class JwtHandler: IJwtHandler
    {
        AppConfiguration config = new AppConfiguration();
        public JwtResponse CreateToken(USER model)
        {
            var now = DateTime.Now;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.JWTSecret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                claims: new Claim[] {
                    new Claim(nameof(model.Id), model.Id.ToString()),
                    new Claim(nameof(model.UserName), model.UserName),
                    //new Claim(nameof(model.Role), claims.Role == null ? "" : claims.Role)
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
