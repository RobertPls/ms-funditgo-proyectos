using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Proyectos
{
    public class ComentarioDto
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
