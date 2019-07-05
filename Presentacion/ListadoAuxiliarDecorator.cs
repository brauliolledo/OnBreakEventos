using Persistencia.lib.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnBreakEventos
{
    public class ListadoAuxiliarDecorator : ListadoContratosViewDecorator
    {
        public class SeleccionContratoArgs : EventArgs
        {
            private ContratoEntity contrato;

            public ContratoEntity Contrato
            {
                get { return contrato; }
                set { contrato = value; }
            }

        }

        public event SeleccionContratoHandler SeleccionContrato;
        public delegate void SeleccionContratoHandler(ListadoAuxiliarDecorator listadoAuxiliarDecorator, SeleccionContratoArgs seleccionContratoArgs);

        
        public ListadoAuxiliarDecorator()
        {



        }

        public override void SetComponent(ListadoContratosView listadoContratosView)
        {
            base.SetComponent(listadoContratosView);

            // Hay opciones particulares a la vista de listado de contratos auxiliar

            ListadoContratosView.btn_seleccionar.Visibility = Visibility.Visible;
            ListadoContratosView.ShowActivated = true;

            ListadoContratosView.btn_seleccionar.Click += new RoutedEventHandler(Btn_seleccionar_Click);
        }

        private void Btn_seleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (ListadoContratosView.dg_contratos.SelectedItem != null)
            {
                SeleccionContratoArgs args = new SeleccionContratoArgs();

                args.Contrato = (ContratoEntity)ListadoContratosView.dg_contratos.SelectedItem;

                SeleccionContrato(this, args);
            }
        }
    }
}
