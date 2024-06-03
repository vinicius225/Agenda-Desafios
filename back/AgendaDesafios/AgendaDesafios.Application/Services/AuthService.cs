using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Application.CommandsAndQueries.Queries;
using AgendaDesafios.Application.Consts;
using AgendaDesafios.Application.DTOs.Auth;
using AgendaDesafios.Application.Exceptions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgendaDesafios.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthService(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        public async Task<AuthLoginResponseDTO> AuthLogin(AuthLoginDTO authLoginDTO)
        {
            try
            {
                var query = new GetUserByLoginQuery(authLoginDTO.Login);
                var _user = await  _mediator.Send(query);

                if (_user == null || _user.Password != SHA256(authLoginDTO.Password))
                {
                    ApplicationExceptions.Error(ExceptionsMessages.INVALID_LOGIN);
                }
                return new AuthLoginResponseDTO(_user.Id, _user.Email, _user.Name, BuildJWT(_user));


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region private methods
        private string SHA256(string input)
        {
            StringBuilder sb = new StringBuilder();

            using (var sha2 = System.Security.Cryptography.SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                Byte[] bytes = sha2.ComputeHash(encoding.GetBytes(input));

                foreach (var item in bytes)
                {
                    sb.Append(item.ToString("X2"));
                }
            }
            return sb.ToString();
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
        #endregion
    }
}
