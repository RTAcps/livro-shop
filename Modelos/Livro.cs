using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroShop.Modelos
{
    public class Livro
    {
        #region Propriedades

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string Editora { get; set; }
        public string ISBN { get; set; }

        #endregion
    }
}
