using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pruebas
{
    [TestClass]
    public class Negocio
    {
        [TestMethod]
        public void ValidacionesFechas()
        {
            // Fecha correcta

            Assert.IsTrue(
                global::Negocio.ValidacionesContrato.Fechas(DateTime.Parse("04/07/2019"), DateTime.Parse("08/07/2019")).Exito);

            // Fechas incorrectas

            Assert.IsFalse(
                global::Negocio.ValidacionesContrato.Fechas(
                    DateTime.Parse("04/07/2019"),
                    DateTime.Parse("02/07/2019")).Exito);

            Assert.IsFalse(
                global::Negocio.ValidacionesContrato.Fechas(
                    DateTime.Parse("04/07/2020"),
                    DateTime.Parse("05/07/2020")).Exito);

            Assert.IsFalse(
                global::Negocio.ValidacionesContrato.Fechas(
                    DateTime.Parse("02/07/2019"),
                    DateTime.Parse("05/07/2020")).Exito);
        }
    }
}
