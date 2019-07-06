using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
    public class TipoEmpresaEntity
    {
        private int id;
        private string descripcion;

        public TipoEmpresaEntity(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public TipoEmpresaEntity()
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


    }
}
