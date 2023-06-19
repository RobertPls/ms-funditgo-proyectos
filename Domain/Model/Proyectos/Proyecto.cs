using Domain.Event.Proyectos;
using Domain.ValueObjects;
using SharedKernel.Core;

namespace Domain.Model.Proyectos
{
    public class Proyecto : AggregateRoot<Guid>
    {
        public TituloValue Titulo { get; private set; }

        public DescripcionValue Descripcion { get; private set; }

        public PrecioValue Monto { get; private set; }


        public Guid CreadorId { get; private set; }


        private readonly ICollection<Colaborador> _colaboradores;
        public IEnumerable<Colaborador> Colaboradores { get { return _colaboradores; } }


        private readonly ICollection<Comentario> _comentarios;
        public IEnumerable<Comentario> Comentarios { get { return _comentarios; } }

        private Proyecto() { }

        internal Proyecto(Guid creadorId, string titulo, string descripcion, decimal monto)
        {
            if (creadorId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();
            CreadorId = creadorId;
            Monto = monto;
            Titulo = titulo;
            Descripcion = descripcion;
            _colaboradores = new List<Colaborador>();
            _comentarios = new List<Comentario>();
        }
        public void AgregarComentario(Guid usuarioId, string texto)
        {
            var comentario = new Comentario(usuarioId, texto);
            _comentarios.Add(comentario);
            AddDomainEvent(new ComentarioAgregado(comentario.Id));
        }

        public void EliminarComentario(Comentario comentario)
        {
            var comentarioExistente = _comentarios.Any(x => x.Id == comentario.Id);

            if (comentarioExistente)
            {
                _comentarios.Remove(comentario);
                AddDomainEvent(new ComentarioEliminado(comentario.Id));
            }
            else
            {
                throw new BussinessRuleValidationException("El comentario no existe en la lista de comentarios del proyecto");
            }
        }

        public void AgregarColaborador(Guid usuarioId)
        {
            var colaboradorExistente = _colaboradores.Any(x => x.UsuarioId == usuarioId);

            if (!colaboradorExistente)
            {
                var colaborador = new Colaborador(usuarioId);
                _colaboradores.Add(colaborador);
                AddDomainEvent(new ColaboradorAgregado(usuarioId));
            }
            else
            {
                throw new BussinessRuleValidationException("Ya existe este colaborador en tu proyecto");
            }
        }

        public void EliminarColaborador(Colaborador colaborador)
        {
            var colaboradorExistente = _colaboradores.Any(x => x.Id == colaborador.Id);

            if (colaboradorExistente)
            {
                _colaboradores.Remove(colaborador);
                AddDomainEvent(new ColaboradorEliminado(colaborador.Id));
            }
            else
            {
                throw new BussinessRuleValidationException("El colaborador no existe en la lista de colaboradores del proyecto");
            }
        }
    }
}
