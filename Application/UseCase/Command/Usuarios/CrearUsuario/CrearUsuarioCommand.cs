using MediatR;

namespace Application.UseCase.Command.Usuarios.CrearUsuario
{
    public record CrearUsuarioCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string NombreCompleto { get; set; }
        public string UserName { get; set; }


        public CrearUsuarioCommand (Guid id, string nombreCompleto, string userName)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            UserName = userName;
        }
    }
}
