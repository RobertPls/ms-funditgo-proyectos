using Application.Dto.Proyectos;
using Azure.Core;
using Domain.Model.Proyectos.Enum;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Query.Proyectos.Mapper
{
    internal static class ProyectoMapper
    {
        public static ProyectoSimpleDto MapToProyectoSimpleDto(ProyectoReadModel proyecto)
        {
            System.Diagnostics.Debug.WriteLine(proyecto.Donaciones == null? true:false);
            var proyectoDto = new ProyectoSimpleDto
            {
                Id = proyecto.Id,
                Titulo = proyecto.Titulo,
                Estado = proyecto.Estado,
                Descripcion = proyecto.Descripcion,
                FechaCreacion = proyecto.FechaCreacion,
                DonacionMinima = proyecto.DonacionMinima,
                PorcentajeDonaciones = CalcularPorcentajeDonaciones(proyecto.DonacionRecibida, proyecto.DonacionEsperada),
                CantidadDonaciones = proyecto.Donaciones.Count(d => d.Estado == EstadoDonacion.Completado.ToString())
            };

            return proyectoDto;
        }

        public static ProyectoSimpleConDonacionTotalSegunUsuarioDto MapToProyectoSimpleConDonacionTotalSegunUsuarioDto(ProyectoReadModel proyecto, Guid usuarioId)
        {
            var proyectoDto = new ProyectoSimpleConDonacionTotalSegunUsuarioDto
            {
                Id = proyecto.Id,
                Titulo = proyecto.Titulo,
                Estado = proyecto.Estado,
                Descripcion = proyecto.Descripcion,
                FechaCreacion = proyecto.FechaCreacion,
                DonacionMinima = proyecto.DonacionMinima,
                PorcentajeDonaciones = CalcularPorcentajeDonaciones(proyecto.DonacionRecibida, proyecto.DonacionEsperada),
                CantidadDonaciones = proyecto.Donaciones.Count(d => d.Estado == EstadoDonacion.Completado.ToString()),
                CantidadDonacionesHechaPorUsuario = proyecto.Donaciones.Where(d => d.Estado == EstadoDonacion.Completado.ToString() && d.UsuarioId == usuarioId).Count(),
                DonacionTotalHechaPorUsuario =  proyecto.Donaciones.Where(d => d.Estado == EstadoDonacion.Completado.ToString() && d.UsuarioId == usuarioId).Sum(d => d.Monto)
            };
            return proyectoDto;
        }

        private static int CalcularPorcentajeDonaciones(decimal donacionRecibida, decimal donacionEsperada)
        {
            decimal porcentaje = (donacionRecibida / donacionEsperada) * 100;
            int porcentajeDonaciones = porcentaje > 100 ? 100 : (int)porcentaje;
            return porcentajeDonaciones;
        }
    }
}
