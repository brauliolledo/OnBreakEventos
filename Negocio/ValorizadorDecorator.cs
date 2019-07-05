using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public abstract class ValorizadorDecorator
    {
        protected Valorizador Valorizador;

        public virtual void SetComponent(Valorizador valorizador)
        {
            // Configuramos el componente

            Valorizador = valorizador;
        }

        public ValorizadorDecorator()
        {

        }

    }
}
