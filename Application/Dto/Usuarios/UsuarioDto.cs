using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Proyectos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        public required string NombreCompleto { get; set; }

    }
}
