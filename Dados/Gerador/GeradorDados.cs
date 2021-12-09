using LivroShop.Dados.Contexto;
using LivroShop.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LivroShop.Dados.Gerador
{
    public class GeradorDados
    {
        public static void InicializarDados(IServiceProvider provedorServico)
        {
            using (var contexto = new LivrosBDcontexto(provedorServico.GetRequiredService<DbContextOptions<LivrosBDcontexto>>()))
            {
                if (contexto.Livros.Any()) 
                { 
                    return; 
                }

                contexto.Livros.AddRange
                    (
                        new Livro
                        {
                            Id= 1,
                            Autor = "Rodrigo",
                            Edicao = 10,
                            Editora = "IGTI Editora",
                            Titulo = "ASP.NET Core Web API",
                            ISBN = "26484DQSD464964DDA"
                        },

                        new Livro
                        {
                            Id = 2,
                            Autor = "Rodrigo",
                            Edicao = 10,
                            Editora = "IGTI Editora",
                            Titulo = "C#",
                            ISBN = "47SFQASFQF54884894"
                        }
                    );

                contexto.SaveChanges();
            }
        }
    }
}
