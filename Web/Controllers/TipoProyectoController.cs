using Application.UseCase.Query.TiposProyectos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{


    [Route("api/tipoProyecto")]
    [ApiController]
    public class TipoProyectoController : ControllerBase
    {
        private readonly ILogger<TipoProyectoController> _logger;
        private readonly IMediator _mediator;

        public TipoProyectoController(IMediator mediator, ILogger<TipoProyectoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetListaTipoProyectoQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
