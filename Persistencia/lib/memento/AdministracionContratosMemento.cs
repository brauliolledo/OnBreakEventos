using Persistencia.lib.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persitencia.lib.memento
{
    public class NullAdministracionContratoMemento : AdministracionContratoMemento
    {
        public NullAdministracionContratoMemento()
            : base()
        {

        }
    }

    public class AdministracionContratoMemento : INotifyPropertyChanged
    {
        private DateTime? _fechaHora;

        public DateTime? FechaHora
        {
            get { return _fechaHora; }
            set { _fechaHora = value; NotifyPropertyChanged(); }
        }


        private ContratoEntity _contrato;

        public ContratoEntity Contrato
        {
            get
            {
                return _contrato;
            }

            set
            {
                _contrato = value;
            }
        }

        public AdministracionContratoMemento()
        {
            Contrato = new NullContratoEntity();
        }

        public AdministracionContratoMemento(ContratoEntity contrato)
        {
            this.Contrato = contrato;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
