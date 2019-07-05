using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class TipoEventoEntity
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private int id;
        private string descripcion;

        public TipoEventoEntity(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public TipoEventoEntity()
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
