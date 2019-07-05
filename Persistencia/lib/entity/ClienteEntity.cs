
using Persistencia.lib.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.app.lib
{
    public class ClienteEntity
    {
        private string rut;
        private string razonSocial;
        private string direccion;
        private string telefono;
        private string nombreContacto;
        private string mailContacto;
        private ActividadEmpresaEntity actividad;
        private TipoEmpresaEntity tipo;

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

        public string Rut { get => rut; set => rut = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public ActividadEmpresaEntity Actividad { get => actividad; set => actividad = value; }
        public TipoEmpresaEntity Tipo { get => tipo; set => tipo = value; }
        public string NombreContacto { get => nombreContacto; set => nombreContacto = value; }
        public string MailContacto { get => mailContacto; set => mailContacto = value; }
    }
}
