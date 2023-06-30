using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCase.Command.Proyectos.CrearProyecto
{
    public record CrearProyectoCommand : IRequest<Guid>
    {
        public Guid CreadorId { get; set; }

        public Guid TipoproyectoId { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Historia { get; set; }
        
        public string CompromisoAmbiental { get; set; }

        public decimal DonacionEsperada { get; set; }

        public decimal DonacionMinima { get; set; }

    }
}
