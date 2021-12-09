using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroShop.Services.Auth.Jwt
{
    public class JwtAuthModelo
    {
        public string TokenAcesso { get; set; }
        public string TokenType { get; set; }
        public int ExpiraEm { get; set; }
    }
}
