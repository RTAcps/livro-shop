using LivroShop.Dados.Contexto;
using LivroShop.Modelos;
using LivroShop.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LivroShop.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LivrosController : ControllerBase
    {
        #region Campos

        private readonly LivrosBDcontexto contexto;

        #endregion

        #region Constructor

        public LivrosController(LivrosBDcontexto contexto)
        {
            this.contexto = contexto;
        }

        #endregion

        #region Metodos
        
        [HttpGet]
        [Authorize(Roles = RolesUsuario.Admin)]
        public async Task<IActionResult> Get()
        {
            var livros = await contexto.Livros.ToListAsync();

            return Ok(livros);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPorId([FromRoute]int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var livro = await contexto.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Livro livro)
        {
            contexto.Livros.Add(livro);

            await contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPorId), new { id = livro.Id}, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            if (!VerificarSeLivroExiste(livro.Id))
            {
                return NotFound();
            }

            contexto.Entry(livro).State = EntityState.Modified;

            await contexto.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await contexto.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            contexto.Livros.Remove(livro);

            await contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool VerificarSeLivroExiste(int id)
        {
            return contexto.Livros.Any(livro => livro.Id == id);
        }

        #endregion
    }
}
