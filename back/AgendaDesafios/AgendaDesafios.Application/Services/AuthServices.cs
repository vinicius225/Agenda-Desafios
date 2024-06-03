using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Services
{
    public class AuthServices : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor ;

        public AuthServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToke(User user)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Time"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    

        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userId);
        }

        public string PasswordHash(string password)
        {
            StringBuilder sb = new StringBuilder();

            using (var sha2 = System.Security.Cryptography.SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                Byte[] bytes = sha2.ComputeHash(encoding.GetBytes(password));

                foreach (var item in bytes)
                {
                    sb.Append(item.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
