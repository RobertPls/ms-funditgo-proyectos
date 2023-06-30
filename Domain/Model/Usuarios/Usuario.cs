using Domain.Event.Usuarios;
using Domain.ValueObjects;
using SharedKernel.Core;

namespace Domain.Model.Usuarios
{
    public class Usuario : AggregateRoot<Guid>
    {
        public NombrePersonaValue NombreCompleto { get; private set; }

        private readonly ICollection<ProyectoFavorito> _proyectosFavoritos;
        public IEnumerable<ProyectoFavorito> ProyectosFavoritos { get { return _proyectosFavoritos; } }
        private Usuario() { }

        internal Usuario(Guid id, string nombreCompleto)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            _proyectosFavoritos = new List<ProyectoFavorito>();
        }

        public void AgregarFavorito(Guid proyectoId)
        {
            var proyectoFavoritoExistente = _proyectosFavoritos.Any(x => x.ProyectoId == proyectoId);

            if (!proyectoFavoritoExistente)
            {
                var proyectoFavorito = new ProyectoFavorito(proyectoId);
                _proyectosFavoritos.Add(proyectoFavorito);
                AddDomainEvent(new ProyectoFavoritoAgregado(proyectoFavorito.Id));
            }
            else
            {
                throw new BussinessRuleValidationException("Ya existe este proyecto en la lista de favoritos");
            }
        }

        public void EliminarFavorito(ProyectoFavorito proyectoFavorito)
        {
            var proyectoFavoritoExistente = _proyectosFavoritos.Any(x => x.Id == proyectoFavorito.Id);

            if (proyectoFavoritoExistente)
            {
                _proyectosFavoritos.Remove(proyectoFavorito);
                AddDomainEvent(new ProyectoFavoritoEliminado(proyectoFavorito.Id));
            }
            else
            {
                throw new BussinessRuleValidationException("El proyecto no existe en la lista de favoritos");
            }
        }
    }
}
