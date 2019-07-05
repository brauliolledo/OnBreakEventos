
using Persistencia.lib.dao;
using Persistencia.lib.entity;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
    public class ContratoEntity
    {
        private string numeroContrato;

        public string NumeroContrato
        {
            get { return numeroContrato; }
            set { numeroContrato = value; }
        }

        private DateTime creacion;

        public DateTime Creacion
        {
            get { return creacion; }
            set { creacion = value; }
        }
        
        // el campo de término de contrato no es obligatorio, asi que usamos un datetime NUllable
        private DateTime termino;

        public DateTime Termino
        {
            get { return termino; }
            set { termino = value; }
        }

        private DateTime inicioEvento;

        public DateTime InicioEvento
        {
            get { return inicioEvento; }
            set { inicioEvento = value; }
        }

        private DateTime terminoEvento;

        public DateTime TerminoEvento
        {
            get { return terminoEvento; }
            set { terminoEvento = value; }
        }

        public bool EstaVigente
        {
            get
            {
                return this.Termino == (DateTime)SqlDateTime.MinValue;
            }
        }

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        private TipoEventoEntity tipo;

        public TipoEventoEntity Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private ClienteEntity cliente;

        public ClienteEntity Cliente
        {
            get { return cliente; }
            set { cliente = value;  }
        }

        private ModalidadServicioEntity modalidadServicio = new ModalidadServicioDAO().BuscarTodo().FirstOrDefault(); // TODO: Implementar correctamente una vez se implemente la lógica de modalidad de servicio

        public ModalidadServicioEntity ModalidadServicio
        {
            get { return modalidadServicio; }
            set { modalidadServicio = value; }
        }


        private int asistentes = 1;

        public int Asistentes
        {
            get { return asistentes; }
            set { asistentes = value; }
        }

        private int personalAdicional = 0;

        public int PersonalAdicional
        {
            get { return personalAdicional; }
            set { personalAdicional = value; }
        }

        private double precioTotal;

        public double PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }

        private bool realizado;

        public bool Realizado
        {
            get { return realizado; }
            set { realizado = value; }
        }



    }
}
