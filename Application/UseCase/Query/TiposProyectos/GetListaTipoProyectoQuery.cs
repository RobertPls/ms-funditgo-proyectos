using Application.Dto.Proyectos;
using Application.Dto.TiposProyectos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Query.TiposProyectos
{
    public class GetListaTipoProyectoQuery : IRequest<IEnumerable<TipoProyectoDto>>
    {
    }
}
