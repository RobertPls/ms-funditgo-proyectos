using Domain.Model.Proyectos;

namespace Domain.Factory.Proyectos
{
    public interface IProyectoFactory
    {
        Proyecto Crear(Guid creadorId, Guid tipoProyectoId, string titulo, string descripcion, string historia, string compromisoAmbiental, decimal donacionEsperada, decimal donacionMinima);
    }
}
