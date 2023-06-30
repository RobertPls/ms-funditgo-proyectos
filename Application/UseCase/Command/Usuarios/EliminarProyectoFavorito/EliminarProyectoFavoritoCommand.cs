using MediatR;

namespace Application.UseCase.Command.Usuarios.EliminarProyectoFavorito
{
    public record EliminarProyectoFavoritoCommand : IRequest<Guid>
    {
        public Guid ProyectoFavoritoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
