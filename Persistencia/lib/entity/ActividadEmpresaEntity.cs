﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class ActividadEmpresaEntity
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private int id;
        private string descripcion;

        public ActividadEmpresaEntity(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public ActividadEmpresaEntity()
        {
            this.Id = 0;
            this.Descripcion = "";
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            var entity = obj as ActividadEmpresaEntity;
            return entity != null &&
                   id == entity.Id &&
                   descripcion == entity.Descripcion;
        }
    }
}
