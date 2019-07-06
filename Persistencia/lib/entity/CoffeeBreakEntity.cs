using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
    public class CoffeeBreakEntity : TipoEventoEntity
    {
        private bool _vegetariana;

        public bool Vegetariana
        {
            get { return _vegetariana; }
            set { _vegetariana = value; }
        }

    }
}
