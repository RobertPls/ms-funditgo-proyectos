using Domain.Model.Proyectos;
using Shared.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    public  class TestProyecto
    {
        //[Fact]
        //public void ProyectoCreation_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();
        //    string estado = "Borrador";
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion,donacionEsperada);

        //    //Assert
        //    Assert.NotNull(proyecto.Titulo);
        //    Assert.Equal(titulo, proyecto.Titulo);

        //    Assert.NotNull(proyecto.Descripcion);
        //    Assert.Equal(descripcion, proyecto.Descripcion);

        //    Assert.NotNull(proyecto.DonacionEsperada);
        //    Assert.True(donacionEsperada == proyecto.DonacionEsperada);

        //    Assert.Equal(estado, proyecto.Estado);
        //}

        //[Fact]
        //public void ProyectoUpdateRevision_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();
        //    string nuevoEstado = "Revision";
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.EnviarARevision();
        //    //Assert         
        //    Assert.Equal(nuevoEstado, proyecto.Estado);
        //}

        //[Fact]
        //public void ProyectoUpdateAceptado_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();
        //    string nuevoEstado = "Aceptado";
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.EnviarARevision();
        //    proyecto.AceptarProyecto();
        //    //Assert
        //    Assert.Equal(nuevoEstado, proyecto.Estado);
        //}

        //[Fact]
        //public void ProyectoUpdateRechazado_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();
        //    string nuevoEstado = "Rechazado";
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.EnviarARevision();
        //    proyecto.RechazarProyecto();
        //    //Assert
        //    Assert.Equal(nuevoEstado, proyecto.Estado);
        //}

        //[Fact]
        //public void ProyectoUpdateObservado_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();
        //    string nuevoEstado = "Observacion";
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.EnviarARevision();
        //    proyecto.EnviarAObservacion();
        //    //Assert
        //    Assert.Equal(nuevoEstado, proyecto.Estado);
        //}

        //[Fact]
        //public void ProyectoAgregarDonacionErrorMonto_Should_Incorrect()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();

        //    var usuarioDonanteId = Guid.NewGuid();
        //    var montoDonacion = 0;

        //    //Act
        //    Action act = () =>
        //    {
        //        //Act
        //        Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //        proyecto.EnviarARevision();
        //        proyecto.AceptarProyecto();
        //        proyecto.AgregarDonacion(usuarioDonanteId, montoDonacion);
        //    };
        //    var exception = Assert.Throws<BussinessRuleValidationException>(act);
        //    var expectedExeption = "No puede ser menor a 1";

        //    //Assert
        //    Assert.NotNull(exception);
        //    Assert.Equal(exception.Message, expectedExeption);
        //}

        //[Fact]
        //public void ProyectoAgregarDonacion_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();

        //    var usuarioDonanteId = Guid.NewGuid();
        //    var montoDonacion = 1;

        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.EnviarARevision();
        //    proyecto.AceptarProyecto();
        //    proyecto.AgregarDonacion(usuarioDonanteId, montoDonacion);
        //    Donacion donacion = proyecto.Donaciones.FirstOrDefault();
        //    proyecto.CompletarDonacion(donacion.Id);
        //    //Assert
        //    Assert.True(montoDonacion == proyecto.DonacionRecibida);
        //}

        //[Fact]
        //public void ProyectoAgregarActualizacionNoEsCreadorNiColaborador_Should_Inorrect()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();

        //    var otroUsuarioId = Guid.NewGuid();
        //    string descripcionActualizacion = "Actualizacion";
        //    //Act
        //    Action act = () =>
        //    {
        //        //Act
        //        Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //        proyecto.AgregarActualizacion(otroUsuarioId, descripcionActualizacion);
        //    };
        //    var exception = Assert.Throws<BussinessRuleValidationException>(act);
        //    var expectedExeption = "No se puede agregar actualizaciones a un proyecto sin aceptar.";

        //    //Assert         
        //    Assert.NotNull(exception);
        //    Assert.Equal(exception.Message, expectedExeption);
        //}

        //[Fact]
        //public void ProyectoAgregarActualizacion_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();

        //    string descripcionActualizacion = "Actualizacion";
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.EnviarARevision();
        //    proyecto.AceptarProyecto();
        //    proyecto.AgregarActualizacion(creadorId, descripcionActualizacion);

        //    Actualizacion actualizacion = proyecto.Actualizaciones.FirstOrDefault();
        //    //Assert
        //    Assert.NotNull(actualizacion);
        //}

        //[Fact]
        //public void ProyectoAgregarColaborador_Should_Correct()
        //{
        //    //Setup
        //    string titulo = "Ayuda social";
        //    string descripcion = "Descripcion Proyecto ayuda social";
        //    decimal donacionEsperada = 10;
        //    var creadorId = Guid.NewGuid();
        //    var tipoId = Guid.NewGuid();

        //    var colaboradorId = Guid.NewGuid();
        //    //Act
        //    Proyecto proyecto = new Proyecto(creadorId, tipoId, titulo, descripcion, donacionEsperada);
        //    proyecto.AgregarColaborador(colaboradorId);

        //    Colaborador colaborador = proyecto.Colaboradores.FirstOrDefault();
        //    //Assert
        //    Assert.NotNull(colaborador);
        //}
    }
}
