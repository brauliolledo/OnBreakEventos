
using Persistencia.lib.dao;
using Persistencia.lib.entity;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.lib.entity
{
    public class NullContratoEntity : ContratoEntity
    {
        public NullContratoEntity()
        {
            this.Creacion = DateTime.Now;
            this.InicioEvento = (DateTime) SqlDateTime.MinValue;
            this.TerminoEvento = (DateTime) SqlDateTime.MinValue;
            this.Termino = (DateTime)SqlDateTime.MinValue;
            this.Cliente = new NullClienteEntity();
        }
    }

    public class ContratoEntity : INotifyPropertyChanged
    {
        private string numeroContrato;

        public string NumeroContrato
        {
            get { return numeroContrato; }
            set { numeroContrato = value; NotifyPropertyChanged(); }
        }

        private DateTime creacion;

        public DateTime Creacion
        {
            get { return creacion; }
            set { creacion = value; NotifyPropertyChanged(); }
        }
        
        // el campo de término de contrato no es obligatorio, asi que usamos un datetime NUllable
        private DateTime termino;

        public DateTime Termino
        {
            get { return termino; }
            set { termino = value; NotifyPropertyChanged(); }
        }

        private DateTime inicioEvento;

        public DateTime InicioEvento
        {
            get { return inicioEvento; }
            set { inicioEvento = value; NotifyPropertyChanged(); }
        }

        private DateTime terminoEvento;

        public DateTime TerminoEvento
        {
            get { return terminoEvento; }
            set { terminoEvento = value; NotifyPropertyChanged(); }
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
            set { observaciones = value; NotifyPropertyChanged(); }
        }

        private TipoEventoEntity tipo;

        public TipoEventoEntity Tipo
        {
            get { return tipo; }
            set
            {
                // Asignamos tipos hijos de TipoEvento dependiendo del id

                if (value != null)
                {
                    ModalidadServicio = null;
                }

                tipo = value;

                NotifyPropertyChanged();
            }
        }

        private ClienteEntity cliente;

        public ClienteEntity Cliente
        {
            get { return cliente; }
            set { cliente = value; NotifyPropertyChanged(); }
        }

        private ModalidadServicioEntity modalidadServicio;

        public ModalidadServicioEntity ModalidadServicio
        {
            get { return modalidadServicio; }
            set { modalidadServicio = value; NotifyPropertyChanged(); }
        }


        private int asistentes = 1;

        public int Asistentes
        {
            get { return asistentes; }
            set { asistentes = value; NotifyPropertyChanged(); }
        }

        private int personalAdicional = 0;

        public int PersonalAdicional
        {
            get { return personalAdicional; }
            set { personalAdicional = value; NotifyPropertyChanged(); }
        }

        private double precioTotal;

        public double PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; NotifyPropertyChanged(); }
        }

        private bool realizado;

        public bool Realizado
        {
            get { return realizado; }
            set { realizado = value; NotifyPropertyChanged();  }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
