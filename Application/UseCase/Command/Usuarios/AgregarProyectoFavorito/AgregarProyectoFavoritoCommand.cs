using MediatR;

namespace Application.UseCase.Command.Usuarios.AgregarProyectoFavorito
{
    public record AgregarProyectoFavoritoCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
