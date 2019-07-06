
using Persistencia.lib.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.app.lib
{
    public class NullClienteEntity : ClienteEntity
    {

    }

    public class ClienteEntity : INotifyPropertyChanged
    {
        private string rut;
        private string razonSocial;
        private string direccion;
        private string telefono;
        private string nombreContacto;
        private string mailContacto;
        private ActividadEmpresaEntity actividad;
        private TipoEmpresaEntity tipo;


        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
                NotifyPropertyChanged();
            }
        }

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
                NotifyPropertyChanged();
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
                NotifyPropertyChanged();
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
                NotifyPropertyChanged();
            }
        }

        public string NombreContacto
        {
            get
            {
                return nombreContacto;
            }

            set
            {
                nombreContacto = value;
                NotifyPropertyChanged();
            }
        }

        public string MailContacto
        {
            get
            {
                return mailContacto;
            }

            set
            {
                mailContacto = value;
                NotifyPropertyChanged();
            }
        }

        public ActividadEmpresaEntity Actividad
        {
            get
            {
                return actividad;
            }

            set
            {
                actividad = value;
                NotifyPropertyChanged();
            }
        }

        public TipoEmpresaEntity Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
                NotifyPropertyChanged();
            }
        }

        public ClienteEntity(string rut, string razonSocial, string direccion, string telefono, string nombreContacto, string mailContacto, ActividadEmpresaEntity actividad, TipoEmpresaEntity tipo)
        {
            this.Rut = "";
            this.RazonSocial = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Actividad = new ActividadEmpresaEntity();
            this.Tipo = new TipoEmpresaEntity();
            this.MailContacto = mailContacto;
            this.NombreContacto = nombreContacto;
        }

        public ClienteEntity()
        {
            this.Rut = "";
            this.RazonSocial = "";
            this.Direccion = "";
            this.Telefono = "";
            this.Actividad = new ActividadEmpresaEntity();
            this.Tipo = new TipoEmpresaEntity();
        }

        public ClienteEntity(string rut, string razonSocial, string direccion, string telefono, ActividadEmpresaEntity actividad, TipoEmpresaEntity tipo)
        {
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Actividad = actividad;
            this.Tipo = tipo;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // Tomado de https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
