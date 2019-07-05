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
                global::Negocio.ValidacionesContrato.Fechas(DateTime.Parse("04/07/2019"), DateTime.Parse("08/07/2019"), DateTime.Now).Exito);

            // Fechas incorrectas

            Assert.IsFalse(
                global::Negocio.ValidacionesContrato.Fechas(
                    DateTime.Parse("04/07/2019"),
                    DateTime.Parse("02/07/2019")
                    , DateTime.Now).Exito);

            Assert.IsFalse(
                global::Negocio.ValidacionesContrato.Fechas(
                    DateTime.Parse("04/07/2020"),
                    DateTime.Parse("05/07/2020"),
                    DateTime.Now).Exito);

            Assert.IsFalse(
                global::Negocio.ValidacionesContrato.Fechas(
                    DateTime.Parse("02/07/2019"),
                    DateTime.Parse("05/07/2020"),
                    DateTime.Now).Exito);
        }
    }
}
