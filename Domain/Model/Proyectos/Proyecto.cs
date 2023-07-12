using Domain.Event.Proyectos;
using Domain.Model.Proyectos.Enum;
using Domain.ValueObjects;
using MediatR;
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

        public DescripcionValue Historia { get; private set; }

        public DescripcionValue CompromisoAmbiental { get; private set; }

        public DonacionValue DonacionEsperada { get; private set; }

        public PrecioValue DonacionRecibida { get; private set; }

        public DonacionValue DonacionMinima { get; private set; }


        private readonly ICollection<Colaborador> _colaboradores;
        public IEnumerable<Colaborador> Colaboradores { get { return _colaboradores; } }



        private readonly ICollection<Comentario> _comentarios;
        public IEnumerable<Comentario> Comentarios { get { return _comentarios; } }



        private readonly ICollection<Actualizacion> _actualizaciones;
        public IEnumerable<Actualizacion> Actualizaciones { get { return _actualizaciones; } }



        private readonly ICollection<Donacion> _donaciones;
        public IEnumerable<Donacion> Donaciones { get { return _donaciones; } }



        public Proyecto(Guid creadorId, Guid tipoProyectoId, string titulo, string descripcion, string historia, string compromisoAmbiental, decimal donacionEsperada, decimal donacionMinima)
        {
            if (creadorId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuarioId es inválido.");
            }

            Id = Guid.NewGuid();

            CreadorId = creadorId;
            TipoProyectoId = tipoProyectoId;

            DonacionEsperada = donacionEsperada;
            DonacionMinima = donacionMinima;
            DonacionRecibida = 0;
            Titulo = titulo;
            Descripcion = descripcion;
            Historia = historia;
            CompromisoAmbiental = historia;

            FechaCreacion = DateTime.Now;

            Estado = nameof(EstadoProyecto.Borrador);

            _colaboradores = new List<Colaborador>();
            _donaciones = new List<Donacion>();
            _actualizaciones = new List<Actualizacion>();
            _comentarios = new List<Comentario>();


        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        public void ActualizarProyecto(decimal donacionEsperada, string descripcion, string historia, string compromisoAmbiental, string titulo)
        {

            if (Estado != nameof(EstadoProyecto.Observacion))
            {
                throw new BussinessRuleValidationException("El proyecto no puede modificarse.");
            }

            DonacionEsperada = donacionEsperada;
            Descripcion = descripcion;
            Titulo = titulo;
            Historia = historia;
            CompromisoAmbiental = compromisoAmbiental;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void EnviarARevision()
        {
            if (Estado != nameof(EstadoProyecto.Borrador) && Estado != nameof(EstadoProyecto.Observacion))
            {
                throw new BussinessRuleValidationException("El estado no puede volver a revision.");
            }
            Estado = nameof(EstadoProyecto.Revision);
        }

        public void EnviarAObservacion()
        {
            if (Estado != nameof(EstadoProyecto.Revision))
            {
                throw new BussinessRuleValidationException("El proyecto necesita ser revisado por un administrador.");
            }
            Estado = nameof(EstadoProyecto.Observacion);
        }

        public void AceptarProyecto()
        {
            if (Estado != nameof(EstadoProyecto.Revision))
            {
                throw new BussinessRuleValidationException("El proyecto no se puede aceptar.");
            }
            Estado = nameof(EstadoProyecto.Aceptado);
        }

        public void RechazarProyecto()
        {
            if (Estado != nameof(EstadoProyecto.Revision))
            {
                throw new BussinessRuleValidationException("El proyecto no se puede rechazar.");
            }
            Estado = nameof(EstadoProyecto.Rechazado);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        public void AgregarActualizacion(Guid usuarioId, string descripcion)
        {
            if (Estado != nameof(EstadoProyecto.Aceptado))
            {
                throw new BussinessRuleValidationException("No se puede agregar actualizaciones a un proyecto sin aceptar.");
            }

            var actualizacion = new Actualizacion(usuarioId, descripcion);
            _actualizaciones.Add(actualizacion);
            AddDomainEvent(new ActualizacionAgregada(actualizacion.Id));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void AgregarDonacion(Guid usuarioId, decimal monto)
        {
            if (Estado != nameof(EstadoProyecto.Aceptado))
            {
                throw new BussinessRuleValidationException("No se puede agregar donaciones a un proyecto sin aceptar.");
            }

            if (monto < DonacionMinima)
            {
                throw new BussinessRuleValidationException($"La donación mínima requerida es de {DonacionMinima}");
            }

            var donacion = new Donacion(usuarioId, monto);
            _donaciones.Add(donacion);
            AddDomainEvent(new DonacionCreada(donacion.Id, this.Id, donacion.Monto));
        }

        public void CompletarDonacion(Guid donacionId)
        {
            var donacionExistente = _donaciones.Any(x => x.Id == donacionId);

            if (!donacionExistente)
            {
                throw new BussinessRuleValidationException("No se encontro la donacion");
            }

            var donacion = _donaciones.FirstOrDefault(x => x.Id == donacionId);
            donacion.CompletarDonacion();
            this.DonacionRecibida += donacion.Monto;
            AddDomainEvent(new DonacionCompletada(donacion.Id));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void AgregarComentario(Guid usuarioId, string texto)
        {
            if (Estado != nameof(EstadoProyecto.Aceptado))
            {
                throw new BussinessRuleValidationException("No se puede agregar comentarios a un proyecto sin aceptar.");
            }

            var comentario = new Comentario(usuarioId, texto);
            _comentarios.Add(comentario);
            AddDomainEvent(new ComentarioAgregado(comentario.Id));
        }

        public void EliminarComentario(Guid comentarioId)
        {
            var comentario = Comentarios.FirstOrDefault(x => x.Id == comentarioId);


            if (comentario == null)
            {
                throw new BussinessRuleValidationException("El comentario no existe en la lista de comentarios del proyecto");
            }

            _comentarios.Remove(comentario);
            AddDomainEvent(new ComentarioEliminado(comentario.Id));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        public void AgregarColaborador(Guid usuarioId)
        {
            if (Estado != nameof(EstadoProyecto.Aceptado))
            {
                throw new BussinessRuleValidationException("No se puede agregar colaboradores a un proyecto sin aceptar.");
            }

            var colaboradorExistente = _colaboradores.Any(x => x.UsuarioId == usuarioId);

            if (colaboradorExistente)
            {
                throw new BussinessRuleValidationException("Ya existe este colaborador en tu proyecto");
            }

            var colaborador = new Colaborador(usuarioId);
            _colaboradores.Add(colaborador);
            AddDomainEvent(new ColaboradorAgregado(usuarioId));
        }

        public void EliminarColaborador(Guid colaboradorId)
        {
            var colaborador = Colaboradores.FirstOrDefault(x => x.Id == colaboradorId);

            if (colaborador == null)
            {
                throw new BussinessRuleValidationException("El colaborador no existe en la lista de colaboradores del proyecto");
            }

            _colaboradores.Remove(colaborador);
            AddDomainEvent(new ColaboradorEliminado(colaborador.Id));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------


        public bool EsCreadorOColaborador(Guid usuarioId)
        {
            return (usuarioId == CreadorId || _colaboradores.Any(c => c.UsuarioId == usuarioId)) ? true : false;
        }

        public bool EsCreador(Guid usuarioId)
        {
            return (usuarioId == CreadorId) ? true : false;
        }

        public bool EsCreadorDelComentario(Guid usuarioId, Guid comentarioId)
        {
            var esCreadorDelComentario = false;
            
            var comentarioExistente = _comentarios.Any(x => x.Id == comentarioId);

            if (comentarioExistente)
            {
                var comentario = _comentarios.FirstOrDefault(x => x.Id == comentarioId);
                esCreadorDelComentario = (comentario!.UsuarioId == usuarioId) ? true : false;
            }

            return esCreadorDelComentario;
        }

        private Proyecto() { }

    }
}
