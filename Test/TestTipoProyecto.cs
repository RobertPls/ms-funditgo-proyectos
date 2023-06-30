using Domain.Model.Proyectos;
using Domain.Model.TiposProyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestTipoProyecto
    {
        [Fact]
        public void TipoProyectoCreation_Should_Correct()
        {
            //Setup
            var nombre = "Construccion";
            var id = Guid.NewGuid();

            //Act
            TipoProyecto proyecto = new TipoProyecto(id, nombre);

            //Assert
            Assert.NotNull(proyecto.Nombre);
            Assert.Equal(nombre, proyecto.Nombre);
        }
    }
}
