using Persistencia.lib.entity;
using Persistencia.OnBreakDataSetTableAdapters;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Persistencia.OnBreakDataSet;

namespace Persistencia.lib.dao
{
    public class ClienteDAO
    {
        private ActividadEmpresaDAO daoA;
        private TipoEmpresaDAO daoT;

        public ClienteDAO() {
            daoA = new ActividadEmpresaDAO();
            daoT = new TipoEmpresaDAO();
        }

        public ClienteEntity BuscarPorRut(string rut)
        {
            ClienteEntity cliente = null;

            ClienteTableAdapter adapter =
                new ClienteTableAdapter();

            ClienteRow fila = adapter.BuscarPorRut(rut).FirstOrDefault();

            if(fila != null)
            {
                cliente = new ClienteEntity();
                cliente.Rut = fila.RutCliente;
                cliente.RazonSocial = fila.RazonSocial;
                cliente.Direccion = fila.Direccion;
                cliente.MailContacto = fila.MailContacto;
                cliente.NombreContacto = fila.NombreContacto;
                cliente.Telefono = fila.Telefono;
                //Llamando a dao actividad para buscar objeto
                cliente.Actividad = daoA.BuscarPorId(fila.IdActividadEmpresa);
                //Llamando a dao tipo para buscar objeto
                cliente.Tipo = daoT.BuscarPorId(fila.IdTipoEmpresa);
            }

            return cliente;
        }

        public List<ClienteEntity> BuscarTodo() {

            List<ClienteEntity> clientes =
                new List<ClienteEntity>();
            //Objeto que realiza CRUD
            ClienteTableAdapter adapter =
                new ClienteTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ClienteRow
                        fila in adapter.GetData()) {
                ClienteEntity cliente
                    = new ClienteEntity();
                cliente.Rut = fila.RutCliente;
                cliente.RazonSocial = fila.RazonSocial;
                cliente.Direccion = fila.Direccion;
                cliente.MailContacto = fila.MailContacto;
                cliente.NombreContacto = fila.NombreContacto;
                cliente.Telefono = fila.Telefono;
                //Llamando a dao actividad para buscar objeto
                cliente.Actividad = daoA.BuscarPorId(fila.IdActividadEmpresa);
                //Llamando a dao tipo para buscar objeto
                cliente.Tipo = daoT.BuscarPorId(fila.IdTipoEmpresa);

                clientes.Add(cliente);
            }

            return clientes;
        }

        public List<ClienteEntity> BuscarCoincidenciasRut(string rut)
        {

            List<ClienteEntity> clientes =
                new List<ClienteEntity>();

            ClienteTableAdapter adapter =
                new ClienteTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ClienteRow
                        fila in adapter.BuscarPorRut(rut))
            {
                ClienteEntity cliente
                    = new ClienteEntity();
                cliente.Rut = fila.RutCliente;
                cliente.RazonSocial = fila.RazonSocial;
                cliente.Direccion = fila.Direccion;
                cliente.MailContacto = fila.MailContacto;
                cliente.NombreContacto = fila.NombreContacto;
                cliente.Telefono = fila.Telefono;
                //Llamando a dao actividad para buscar objeto
                cliente.Actividad = daoA.BuscarPorId(fila.IdActividadEmpresa);
                //Llamando a dao tipo para buscar objeto
                cliente.Tipo = daoT.BuscarPorId(fila.IdTipoEmpresa);

                clientes.Add(cliente);
            }

            return clientes;
        }

        public void Crear(ClienteEntity cliente) {

            //Creacion de objeto Adaptador  de la tabla Cliente que 
            //posee el CRUD
            ClienteTableAdapter adapter =
                    new ClienteTableAdapter();

            //Llamamos al método insertar del adaptador
            adapter.Insert(cliente.Rut,
                cliente.RazonSocial, cliente.NombreContacto,
                cliente.MailContacto, cliente.Direccion,
                cliente.Telefono, int.Parse(cliente.Actividad.Id.ToString()),
                int.Parse(cliente.Tipo.Id.ToString()));
        }

        public void Eliminar(string rut)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();

            adapter.EliminarPorRut(rut);
        }
        
        public void Modificar(ClienteEntity cliente)
        {            
            ClienteTableAdapter adapter = new ClienteTableAdapter();

            adapter.Modificar(
                cliente.RazonSocial, cliente.NombreContacto,
                cliente.MailContacto, cliente.Direccion,
                cliente.Telefono, cliente.Actividad.Id,
                cliente.Tipo.Id, cliente.Rut);
        }
    }
}
