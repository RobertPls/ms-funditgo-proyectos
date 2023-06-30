namespace Application.Dto.Proyectos
{
    public class ProyectoSimpleConDonacionTotalSegunUsuarioDto : ProyectoSimpleDto
    {
        public int CantidadDonacionesHechaPorUsuario { get; set; }
        public decimal DonacionTotalHechaPorUsuario { get; set; }

    }
}
