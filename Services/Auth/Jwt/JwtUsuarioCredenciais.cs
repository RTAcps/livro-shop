
using System.ComponentModel.DataAnnotations;

namespace LivroShop.Services.Auth.Jwt
{
    public class JwtUsuarioCredenciais
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
