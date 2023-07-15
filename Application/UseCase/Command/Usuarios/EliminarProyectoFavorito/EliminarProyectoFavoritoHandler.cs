using Application.UseCase.Command.Usuarios.AgregarProyectoFavorito;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using MediatR;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Command.Usuarios.EliminarProyectoFavorito
{
    public class EliminarProyectoFavoritoHandler : IRequestHandler<EliminarProyectoFavoritoCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarProyectoFavoritoHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWort)
        {
            _usuarioRepository = usuarioRepository;

            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarProyectoFavoritoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            var proyectoFavorito = usuario.ProyectosFavoritos.FirstOrDefault(x => x.Id == request.ProyectoFavoritoId);

            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            if (proyectoFavorito == null)
            {
                throw new BussinessRuleValidationException("Proyecto favorito no encontrado");
            }

            usuario.EliminarFavorito(proyectoFavorito);

            await _usuarioRepository.UpdateAsync(usuario);

            await _unitOfWork.Commit();

            return usuario.Id;
        }
    }
}
