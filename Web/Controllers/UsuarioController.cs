using Application.UseCase.Command.Usuarios.AgregarProyectoFavorito;
using Application.UseCase.Command.Usuarios.CrearUsuario;
using Application.UseCase.Command.Usuarios.EliminarProyectoFavorito;
using Application.UseCase.Query.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, ILogger<UsuarioController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el usuario");
                return BadRequest();
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetUsuarioByIdQuery()
            {
                UsuarioId = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("favorito")]
        [HttpPost]
        public async Task<IActionResult> AgregarProyectoFavorito([FromBody] AgregarProyectoFavoritoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el proyecto a favorito el proyecto");
                return BadRequest();
            }
        }

        [Route("favorito")]
        [HttpDelete]
        public async Task<IActionResult> EliminarProyectoFavorito([FromBody] EliminarProyectoFavoritoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el proyecto favorito");
                return BadRequest();
            }
        }

    }
}
