using LivroShop.Dados.Repositorio.Interfaces;
using LivroShop.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LivroShop.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class UsuariosController : ControllerBase
    {
        #region Campos

        private readonly IUsuarioRepositorio usuarioRepositorio;

        #endregion

        #region Construtor

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await usuarioRepositorio.RecuperarTodosAsync();

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!usuario.EhValido())
                {
                    return BadRequest();
                }

                var affectRows = await usuarioRepositorio.AdicionarAsync(usuario);

                if (affectRows == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    CodigoStatus = StatusCodes.Status500InternalServerError,
                    Mensagem = e.Message
                });
            }
        }

        #endregion
    }
}
