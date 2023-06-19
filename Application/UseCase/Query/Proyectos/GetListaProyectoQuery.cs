using Application.Dto.Proyectos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Query.Proyectos
{
    public class GetListaProyectoQuery : IRequest<IEnumerable<ProyectoDto>>
    {
        public string TituloSearchTerm { get; set; }
    }
}
