using Application.Dto.Proyectos;
using Application.Dto.TiposProyectos;
using Application.Dto.Usuarios;
using Azure.Core;
using Domain.Model.Proyectos.Enum;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Query.Proyectos.Mapper
{
    internal static class ProyectoMapper
    {
        public static ProyectoDto MapToProyectoDto(ProyectoReadModel proyecto)
        {
            var proyectoDto = new ProyectoDto
            {
                Id = proyecto.Id,
                FechaCreacion = proyecto.FechaCreacion,
                Estado = proyecto.Estado,
                Titulo = proyecto.Titulo,
                Descripcion = proyecto.Descripcion,
                Historia = proyecto.Historia,
                CompromisoAmbiental = proyecto.CompromisoAmbiental,
                DonacionEsperada = proyecto.DonacionEsperada,
                DonacionRecibida = proyecto.DonacionRecibida,
                DonacionMinima = proyecto.DonacionMinima,
                PorcentajeDonaciones = CalcularPorcentajeDonaciones(proyecto.DonacionRecibida, proyecto.DonacionEsperada),
                CantidadDonaciones = proyecto.Donaciones.Count(d => d.Estado == EstadoDonacion.Completado.ToString()),
                Creador = new UsuarioSimpleDto { Id = proyecto.Creador.Id, NombreCompleto = proyecto.Creador.NombreCompleto, UserName = proyecto.Creador.UserName },
                Tipo = new TipoProyectoDto { Id = proyecto.TipoProyecto.Id, Nombre = proyecto.TipoProyecto.Nombre },
                Comentarios = proyecto.Comentarios.Select(c => new ComentarioDto
                {
                    Id = c.Id,
                    Texto = c.Texto,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto, UserName = c.Usuario.UserName },

                }).ToList(),
                Colaboradores = proyecto.Colaboradores.Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto, UserName = c.Usuario.UserName },
                }).ToList(),
                Actualizaciones = proyecto.Actualizaciones.Select(c => new ActualizacionDto
                {
                    Id = c.Id,
                    Fecha = c.Fecha,
                    Descripcion = c.Descripcion,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto, UserName = c.Usuario.UserName },
                }).ToList(),
                Donaciones = proyecto.Donaciones.Where(d => d.Estado == EstadoDonacion.Completado.ToString()).Select(c => new DonacionDto
                {
                    Id = c.Id,
                    Monto = c.Monto,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto, UserName = c.Usuario.UserName },
                    Estado = c.Estado,
                }).ToList()
            };

            return proyectoDto;
        }

        public static ProyectoSimpleDto MapToProyectoSimpleDto(ProyectoReadModel proyecto)
        {
            var proyectoDto = new ProyectoSimpleDto
            {
                Id = proyecto.Id,
                TipoProyecto = proyecto.TipoProyecto.Nombre,
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
                TipoProyecto = proyecto.TipoProyecto.Nombre,
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
