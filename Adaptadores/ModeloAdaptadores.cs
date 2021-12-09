using System;
using LivroShop.Modelos;
using LivroShop.Services.Auth.Jwt;

namespace LivroShop.Adaptadores
{
    public static class ModeloAdaptadores
    {
        public static JwtCredenciais ParaJwtCredenciais(this Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException();
            }

            return new JwtCredenciais
            {
                Email = usuario.Email,
                Senha = usuario.Senha,
                Role = usuario.Role
            };
        }
    }
}
