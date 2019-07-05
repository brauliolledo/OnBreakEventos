using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class ModalidadServicioEntity
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private string id;

        public string Id { get => id; set => id = value; }

        private string nombre;

        public string Nombre { get => nombre; set => nombre = value; }

        private double valorBase;

        public double ValorBase
        {
            get { return valorBase; }
            set { valorBase = value; }
        }

        private int personalBase;

        public int PersonalBase
        {
            get { return personalBase; }
            set { personalBase = value; }
        }

        private TipoEventoEntity tipoEvento;

        public TipoEventoEntity TipoEvento
        {
            get { return tipoEvento; }
            set { tipoEvento = value; }
        }


        public ModalidadServicioEntity(string id, string nombre, int valorBase, int personalBase)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.ValorBase = valorBase;
            this.PersonalBase = personalBase;
        }

        public ModalidadServicioEntity()
        {
            this.Id = "0";
            this.Nombre = "";
            this.ValorBase = 0;
            this.PersonalBase = 0;
        }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            var entity = obj as ModalidadServicioEntity;
            return entity != null &&
                   id == entity.Id &&
                   nombre == entity.Nombre;
        }
    }
}
