using Domain.Model.Proyectos;
using Domain.Model.Proyectos.Enum;
using Shared.Core;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    public  class TestProyecto
    {
        [Fact]
        public void ProyectoCreation_Should_Correct()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 1;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();
            string estado = nameof(EstadoProyecto.Borrador);
            //Act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental,donacionEsperada, donacionMinima);

            //Assert
            Assert.NotNull(proyecto.Titulo);
            Assert.Equal(titulo, proyecto.Titulo);

            Assert.NotNull(proyecto.Descripcion);
            Assert.Equal(descripcion, proyecto.Descripcion);

            Assert.NotNull(proyecto.DonacionEsperada);
            Assert.True(donacionEsperada == proyecto.DonacionEsperada);

            Assert.Equal(estado, proyecto.Estado);
        }

        [Fact]
        public void ProyectoCreation_Should_Incorrect()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 0;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();
            string estado = nameof(EstadoProyecto.Borrador);

            //Act
            Action act = () =>
            {
                Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            };
            var exception = Assert.Throws<BussinessRuleValidationException>(act);
            var expectedExeption = "No puede ser menor a 1";

            //Assert         
            Assert.NotNull(exception);
            Assert.Equal(exception.Message, expectedExeption);
        }

        [Fact]
        public void proyectoUpdateRevision_Should_Correct()
        {
            //setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 1;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();
            string estadoRevision = nameof(EstadoProyecto.Revision);
            //act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            proyecto.EnviarARevision();
            //assert         
            Assert.Equal(estadoRevision, proyecto.Estado);
        }

        [Fact]
        public void ProyectoUpdateAceptado_Should_Correct()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 1;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();
            string estadoAceptado = nameof(EstadoProyecto.Aceptado);
            //Act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            proyecto.EnviarARevision();
            proyecto.AceptarProyecto();
            //Assert
            Assert.Equal(estadoAceptado, proyecto.Estado);
        }

        [Fact]
        public void ProyectoUpdateRechazado_Should_Correct()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 1;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();
            string estadoRechazado= nameof(EstadoProyecto.Rechazado);
            //Act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            proyecto.EnviarARevision();
            proyecto.RechazarProyecto();
            //Assert
            Assert.Equal(estadoRechazado, proyecto.Estado);
        }

        [Fact]
        public void ProyectoAgregarDonacionErrorMonto_Should_Incorrect()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 2;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();

            var usuarioDonanteId = Guid.NewGuid();
            var montoDonacion = 1;

            //Act
            Action act = () =>
            {
                Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
                proyecto.EnviarARevision();
                proyecto.AceptarProyecto();
                proyecto.AgregarDonacion(usuarioDonanteId, montoDonacion);
            };
            var exception = Assert.Throws<BussinessRuleValidationException>(act);
            var expectedExeption = $"La donación mínima requerida es de {donacionMinima}";

            //Assert
            Assert.NotNull(exception);
            Assert.Equal(exception.Message, expectedExeption);
        }

        [Fact]
        public void ProyectoAgregarDonacion_Should_Correct()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 2;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();

            var usuarioDonanteId = Guid.NewGuid();
            var montoDonacion = 2;

            //Act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            proyecto.EnviarARevision();
            proyecto.AceptarProyecto();
            proyecto.AgregarDonacion(usuarioDonanteId, montoDonacion);
            Donacion donacion = proyecto.Donaciones.FirstOrDefault();
            proyecto.CompletarDonacion(donacion.Id);
            //Assert
            Assert.True(montoDonacion == proyecto.DonacionRecibida);
        }

        [Fact]
        public void ProyectoSinAceptarAgregarActualizacion_Should_Inorrect()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 2;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();

            string descripcionActualizacion = "Actualizacion";

            //Act
            Action act = () =>
            {
                Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
                proyecto.AgregarActualizacion(creadorId, descripcionActualizacion);
            };
            var exception = Assert.Throws<BussinessRuleValidationException>(act);
            var expectedExeption = "No se puede agregar actualizaciones a un proyecto sin aceptar.";

            //Assert         
            Assert.NotNull(exception);
            Assert.Equal(exception.Message, expectedExeption);
        }

        [Fact]
        public void ProyectoAgregarActualizacion_Should_Correct()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 2;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();

            string descripcionActualizacion = "Actualizacion";

            //Act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            proyecto.EnviarARevision();
            proyecto.AceptarProyecto();
            proyecto.AgregarActualizacion(creadorId, descripcionActualizacion);

            Actualizacion actualizacion = proyecto.Actualizaciones.FirstOrDefault();
            //Assert
            Assert.Equal(actualizacion.Descripcion, descripcionActualizacion);
        }

        [Fact]
        public void ProyectoAgregarColaborador_Should_Correct()
        {
            //Setup
            string titulo = "Ayuda social";
            string descripcion = "Descripcion Proyecto ayuda social";
            string historia = "Historia Proyecto ayuda social";
            string compromisoAmbiental = "Compromiso ambiental Proyecto ayuda social";
            decimal donacionEsperada = 10;
            decimal donacionMinima = 2;
            var creadorId = Guid.NewGuid();
            var tipoId = Guid.NewGuid();

            var colaboradorId = Guid.NewGuid();
            //Act
            Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            proyecto.EnviarARevision();
            proyecto.AceptarProyecto();
            proyecto.AgregarColaborador(colaboradorId);

            Colaborador colaborador = proyecto.Colaboradores.FirstOrDefault();
            //Assert
            Assert.Equal(colaborador.UsuarioId, colaboradorId);
        }
    }
}

