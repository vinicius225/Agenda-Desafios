using AgendaDesafios.Application.DTOs;
using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Login.Queries
{
    public class AuthUserQueryHandler : IRequestHandler<AuthUserQuery, AuthDTO>
    {
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IConfiguration _configuration;

        public AuthUserQueryHandler(IUserDapperRepository userDapperRepository, IConfiguration configuration)
        {
            _userDapperRepository = userDapperRepository;
            _configuration = configuration;
        }

        public async Task<AuthDTO> Handle(AuthUserQuery request, CancellationToken cancellationToken)
        {
            var _user = await _userDapperRepository.GetByLogin(request.Login);
            if (_user == null || _user.Password != SHA256( request.Password)) 
            {
                return null;
            }
            return new AuthDTO
            {
                email = _user.Email,
                Name = _user.Name,
                token = BuildJWT(_user)

            };

        }

        private string BuildJWT(User login)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.Name),
                    new Claim(ClaimTypes.NameIdentifier, login.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string SHA256(string input)
        {
            StringBuilder sb = new StringBuilder();

            using (var sha2 = System.Security.Cryptography.SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                Byte[] bytes = sha2.ComputeHash(encoding.GetBytes(input));

                foreach (var item in bytes)
                {
                    sb.Append(item.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }

}
