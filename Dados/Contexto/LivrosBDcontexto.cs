using LivroShop.Modelos;
using Microsoft.EntityFrameworkCore;


namespace LivroShop.Dados.Contexto
{
    public class LivrosBDcontexto : DbContext
    {
        #region Contructor

        public LivrosBDcontexto(DbContextOptions<LivrosBDcontexto> options)
            : base(options) { }

        #endregion

        #region Propriedades

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        #endregion
    }
}
