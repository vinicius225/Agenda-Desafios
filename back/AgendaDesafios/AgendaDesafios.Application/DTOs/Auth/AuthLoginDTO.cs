using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.DTOs.Auth
{
    public class AuthLoginDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }

    }
    public class AuthLoginResponseDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public AuthLoginResponseDTO() { }

        public AuthLoginResponseDTO(int id, string login, string name, string token)
        {
            this.Id = id;
            this.Login = login;
            this.Name = name;
            this.Token = token;
        }
    }
}
