using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistencia.lib.dao;
using Persistencia.lib.entity;

namespace TestOnBreak
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IntegridadTipoEmpresaEntity()
        {
            int id = 1;
            string descripcion = "testtesttesttest";

            TipoEmpresaEntity tipoE = new TipoEmpresaEntity(
                id, descripcion);
            Assert.AreEqual(id, tipoE.Id);
            Assert.AreEqual(descripcion, tipoE.Descripcion);
        }
        [TestMethod]
        public void BuscarTodoTipoEmpresa() {

            TipoEmpresaDAO dao = new TipoEmpresaDAO();
            List<TipoEmpresaEntity> tiposE = dao.BuscarTodo();
            Assert.AreNotEqual(0, tiposE.Count);
        }
    }
}
