using Persistencia.lib.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakEventos
{
    public abstract class ListadoContratosViewDecorator
    {
        protected ListadoContratosView ListadoContratosView;

        public ListadoContratosViewDecorator()
        {

        }

        public virtual void SetComponent(ListadoContratosView listadoContratosView)
        {
            // Configuramos el componente

            ListadoContratosView = listadoContratosView;
        }

    }
}
