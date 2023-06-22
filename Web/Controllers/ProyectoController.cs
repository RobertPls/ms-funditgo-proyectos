using Application.UseCase.Command.Proyectos.AgregarActualizacion;
using Application.UseCase.Command.Proyectos.AgregarColaborador;
using Application.UseCase.Command.Proyectos.CrearProyecto;
using Application.UseCase.Command.Proyectos.EliminarColaborador;
using Application.UseCase.Command.Proyectos.EliminarProyecto;
using Application.UseCase.Query.Proyectos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/proyecto")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ILogger<ProyectoController> _logger;
        private readonly IMediator _mediator;

        public ProyectoController(IMediator mediator, ILogger<ProyectoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearProyecto([FromBody] CrearProyectoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el proyecto");
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarProyecto([FromBody] EliminarProyectoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el proyecto");
                return BadRequest();
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetProyectoByIdQuery()
            {
                ProyectoId = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("buscar")]
        [HttpGet]
        public async Task<IActionResult> BuscarProyecto([FromQuery] string? titulo)
        {
            var query = new GetListaProyectoQuery
            {
                TituloSearchTerm = titulo
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("colaborador")]
        [HttpPost]
        public async Task<IActionResult> AgregarColaborador([FromBody] AgregarColaboradorCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el colaborador");
                return BadRequest();
            }
        }

        [Route("colaborador")]
        [HttpDelete]
        public async Task<IActionResult> EliminarColaborador([FromBody] EliminarColaboradorCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el colaborador");
                return BadRequest();
            }
        }

        [Route("comentario")]
        [HttpPost]
        public async Task<IActionResult> AgregarComentario([FromBody] AgregarComentarioCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el comentario");
                return BadRequest();
            }
        }

        [Route("comentario")]
        [HttpDelete]
        public async Task<IActionResult> EliminarComentario([FromBody] EliminarComentarioCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el comentario");
                return BadRequest();
            }
        }

        [Route("actualizacion")]
        [HttpPost]
        public async Task<IActionResult> AgregarActualizacion([FromBody] AgregarActualizacionCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar la actualizacion");
                return BadRequest();
            }
        }

    }
}
