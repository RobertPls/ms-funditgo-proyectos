using MediatR;

namespace Application.UseCase.Command.Usuarios.CrearUsuario
{
    public record CrearUsuarioCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string NombreCompleto { get; set; }

        public CrearUsuarioCommand (Guid id, string nombreCompleto)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
        }
    }
}
