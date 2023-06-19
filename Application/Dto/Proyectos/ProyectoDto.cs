using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Proyectos
{
    public class ProyectoDto
    {
        public Guid Id { get; set; }
        public UsuarioDto Creador { get; set; }

        public required string Titulo { get; set; }

        public required string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public required ICollection<ComentarioDto> Comentarios { get; set; }
        public required ICollection<ColaboradorDto> Colaboradores { get; set; }
    }
}
