using Domain.Event.Proyectos;
using Domain.Model.Proyectos.Enum;
using Domain.ValueObjects;
using SharedKernel.Core;

namespace Domain.Model.Proyectos
{
    public class Proyecto : AggregateRoot<Guid>
    {
        public Guid CreadorId { get; private set; }

        public Guid TipoProyectoId { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        public string Estado { get; private set; }

        public TituloValue Titulo { get; private set; }

        public DescripcionValue Descripcion { get; private set; }

        public DonacionValue DonacionEsperada { get; private set; }

        public PrecioValue DonacionRecibida { get; private set; }

        private readonly ICollection<Colaborador> _colaboradores;
        public IEnumerable<Colaborador> Colaboradores { get { return _colaboradores; } }



        private readonly ICollection<Comentario> _comentarios;
        public IEnumerable<Comentario> Comentarios { get { return _comentarios; } }



        private readonly ICollection<Actualizacion> _actualizaciones;
        public IEnumerable<Actualizacion> Actualizaciones { get { return _actualizaciones; } }



        private readonly ICollection<Donacion> _donaciones;
        public IEnumerable<Donacion> Donaciones { get { return _donaciones; } }



        public Proyecto(Guid creadorId, Guid tipoProyectoId, string titulo, string descripcion, decimal donacionEsperada)
        {
            if (creadorId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();

            CreadorId = creadorId;
            TipoProyectoId = tipoProyectoId;

            DonacionEsperada = donacionEsperada;
            Titulo = titulo;
            Descripcion = descripcion;

            FechaCreacion = DateTime.Now;

            DonacionRecibida = 0;

            Estado = nameof(EstadoProyecto.Borrador);

            _colaboradores = new List<Colaborador>();
            _donaciones = new List<Donacion>();
            _actualizaciones = new List<Actualizacion>();
            _comentarios = new List<Comentario>();


        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void EnviarARevision()
        {
            if (Estado != nameof(EstadoProyecto.Borrador) || Estado != nameof(EstadoProyecto.Observacion))
            {
                throw new BussinessRuleValidationException("El estado no puede volver a revision.");
            }
            Estado = nameof(EstadoProyecto.Revision);
        }

        public void EnviarObservacion()
        {
            if (Estado != nameof(EstadoProyecto.Revision))
            {
                throw new BussinessRuleValidationException("El estado no puede volver a revision.");
            }
            Estado = nameof(EstadoProyecto.Observacion);
        }

        public void AceptarProyecto()
        {
            if (Estado != nameof(EstadoProyecto.Revision))
            {
                throw new BussinessRuleValidationException("El estado no puede aceptarse.");
            }
            Estado = nameof(EstadoProyecto.Aceptado);
        }

        public void RechazarProyecto()
        {
            if (Estado != nameof(EstadoProyecto.Revision))
            {
                throw new BussinessRuleValidationException("El estado no puede rechazarse.");
            }
            Estado = nameof(EstadoProyecto.Rechazado);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        public void AgregarActualizacion(Guid usuarioId, string descripcion)
        {
            var actualizacion = new Actualizacion(usuarioId, descripcion);
            _actualizaciones.Add(actualizacion);
            AddDomainEvent(new ActualizacionAgregada(actualizacion.Id));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void AgregarDonacion(Guid usuarioId, decimal monto)
        {
            var donacion = new Donacion(usuarioId, monto);
            _donaciones.Add(donacion);
            AddDomainEvent(new DonacionCreada(donacion.Id));
        }

        public void CompletarDonacion(Guid donacionId)
        {
            var donacionExistente = _donaciones.Any(x => x.Id == donacionId);

            if (donacionExistente)
            {
                var donacion = _donaciones.FirstOrDefault(x => x.Id == donacionId);
                donacion.CompletarDonacion();
                this.DonacionRecibida += donacion.Monto;
            }
            else
            {
                throw new BussinessRuleValidationException("No se encontro la donacion");
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

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

        //-------------------------------------------------------------------------------------------------------------------------------------

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

        //-------------------------------------------------------------------------------------------------------------------------------------


        public bool EsCreadorOColaborador(Guid usuarioId)
        {
            return (usuarioId == CreadorId || _colaboradores.Any(c => c.UsuarioId == usuarioId)) ? true : false;
        }

        private Proyecto() { }

    }
}
