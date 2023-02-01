using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProiectV1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProiectV1.Helpers;

namespace ProiectV1.Helpers.JwtUtils
{
    public class JwtUtilsC : IJwtUtils
    {
        public readonly AppSettings _appSettings;

        public JwtUtilsC(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
        
            var appPrivateKey = Encoding.ASCII.GetBytes(_appSettings.JwtToken);
            
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //ce retinem in token
                    Subject = new ClaimsIdentity(
                        new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(11),
                    //cum se hash-este parola
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appPrivateKey), SecurityAlgorithms.HmacSha384Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
           
        }

        //validare
        public Guid ValidateJwtToken(string token)
        {
            if(token == null)
            {
                return Guid.Empty;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var appPrivateKey = Encoding.ASCII.GetBytes(_appSettings.JwtToken);

            var TokenValidationParameters = new TokenValidationParameters
            {
                //sa fie validata cheia noastra
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(appPrivateKey),
                //validam provider-ul token-ului
                ValidateIssuer = true,
                //clientul inca nu este validat
                ValidateAudience = false,
                //timp de validare
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                tokenHandler.ValidateToken(token, TokenValidationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = new Guid(jwtToken.Claims.FirstOrDefault(x => x.Type == "id").Value);
                return userId;
            }
            catch 
            {
                return Guid.Empty;
            }
            
        }
    }
}
