using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Persistencia.OnBreakDataSet;
using Persistencia.lib.entity;
using Persistencia.OnBreakDataSetTableAdapters;
using Presentacion.app.lib;

namespace Persistencia.lib.dao
{
    public class ContratoDAO
    {
        private ClienteDAO clienteDAO;
        private TipoEventoDAO tipoEventoDAO;
        private ModalidadServicioDAO modalidadServicioDAO;


        public ContratoDAO()
        {
            clienteDAO = new ClienteDAO();
            tipoEventoDAO = new TipoEventoDAO();
            modalidadServicioDAO = new ModalidadServicioDAO();
        }

        /// <summary>
        /// Búsqueda individual
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public ContratoEntity BuscarPorNumero(string numero)
        {
            ContratoRow filaCoincidente = new ContratoTableAdapter().BuscarPorNumero(numero).FirstOrDefault();

            if(filaCoincidente != null)
            {
                ContratoEntity filaComoContrato = new ContratoEntity();

                filaComoContrato.NumeroContrato = filaCoincidente.Numero;
                filaComoContrato.Creacion = filaCoincidente.Creacion;
   
                filaComoContrato.Termino = filaCoincidente.Termino;
                filaComoContrato.Cliente = clienteDAO.BuscarPorRut(filaCoincidente.RutCliente); // Si no lo encuentra, queda nulo
                filaComoContrato.Tipo = tipoEventoDAO.BuscarPorId(filaCoincidente.IdTipoEvento);
                filaComoContrato.ModalidadServicio = modalidadServicioDAO.BuscarPorId(filaCoincidente.IdModalidad);
                filaComoContrato.InicioEvento = filaCoincidente.FechaHoraInicio;
                filaComoContrato.TerminoEvento = filaCoincidente.FechaHoraTermino;
                filaComoContrato.Asistentes = filaCoincidente.Asistentes;
                filaComoContrato.PersonalAdicional = filaCoincidente.PersonalAdicional;
                filaComoContrato.Realizado = filaCoincidente.Realizado;
                filaComoContrato.PrecioTotal = filaCoincidente.ValorTotalContrato;

                return filaComoContrato;
            }

            return null;
        }
        public List<ContratoEntity> BuscarCoincidenciasNumero(string numero)
        {
            List<ContratoEntity> contratos = new List<ContratoEntity>();

            ContratoTableAdapter adapter = new ContratoTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ContratoRow
                        fila in adapter.BuscarPorNumero(numero))
            {
                ContratoEntity contrato
                    = new ContratoEntity();

                contrato.NumeroContrato = fila.Numero;
                contrato.Creacion = fila.Creacion;
                contrato.Termino = fila.Termino;
                contrato.Cliente = clienteDAO.BuscarPorRut(fila.RutCliente); // Si no lo encuentra, queda nulo
                contrato.Tipo = tipoEventoDAO.BuscarPorId(fila.IdTipoEvento);
                contrato.ModalidadServicio = modalidadServicioDAO.BuscarPorId(fila.IdModalidad);
                contrato.InicioEvento = fila.FechaHoraInicio;
                contrato.TerminoEvento = fila.FechaHoraTermino;
                contrato.Asistentes = fila.Asistentes;
                contrato.PersonalAdicional = fila.PersonalAdicional;
                contrato.Realizado = fila.Realizado;
                contrato.PrecioTotal = fila.ValorTotalContrato;

            }


            return contratos;
        }

        public List<ContratoEntity> BuscarTodo()
        {
            List<ContratoEntity> contratos = new List<ContratoEntity>();

            ContratoTableAdapter adapter = new ContratoTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ContratoRow
                        fila in adapter.GetData())
            {
                ContratoEntity contrato
                    = new ContratoEntity();

                contrato.NumeroContrato = fila.Numero;
                contrato.Creacion = fila.Creacion;
                contrato.Termino = fila.Termino;
                contrato.Cliente = clienteDAO.BuscarPorRut(fila.RutCliente); // Si no lo encuentra, queda nulo
                contrato.Tipo = tipoEventoDAO.BuscarPorId(fila.IdTipoEvento);
                contrato.ModalidadServicio = modalidadServicioDAO.BuscarPorId(fila.IdModalidad);
                contrato.InicioEvento = fila.FechaHoraInicio;
                contrato.TerminoEvento = fila.FechaHoraTermino;
                contrato.Asistentes = fila.Asistentes;
                contrato.PersonalAdicional = fila.PersonalAdicional;
                contrato.Realizado = fila.Realizado;
                contrato.PrecioTotal = fila.ValorTotalContrato;

                contratos.Add(contrato);
            }


            return contratos;
        }

        public List<ContratoEntity> BuscarContratosCliente(ClienteEntity cliente)
        {
            List<ContratoEntity> contratos = new List<ContratoEntity>();

            ContratoTableAdapter adapter = new ContratoTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ContratoRow
                        fila in adapter.BuscarPorRutCliente(cliente.Rut))
            {
                ContratoEntity contrato
                    = new ContratoEntity();

                contrato.NumeroContrato = fila.Numero;
                contrato.Creacion = fila.Creacion;
                contrato.Termino = fila.Termino;
                contrato.Cliente = cliente;
                contrato.Tipo = tipoEventoDAO.BuscarPorId(fila.IdTipoEvento);
                contrato.ModalidadServicio = modalidadServicioDAO.BuscarPorId(fila.IdModalidad);
                contrato.InicioEvento = fila.FechaHoraInicio;
                contrato.TerminoEvento = fila.FechaHoraTermino;
                contrato.Asistentes = fila.Asistentes;
                contrato.PersonalAdicional = fila.PersonalAdicional;
                contrato.Realizado = fila.Realizado;
                contrato.PrecioTotal = fila.ValorTotalContrato;

                contratos.Add(contrato);
            }


            return contratos;
        }

        public List<ContratoEntity> BuscarCoincidenciasRutCliente(string rut)
        {
            List<ContratoEntity> contratos = new List<ContratoEntity>();

            ContratoTableAdapter adapter = new ContratoTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ContratoRow
                        fila in adapter.BuscarPorRutCliente(rut))
            {
                ContratoEntity contrato
                    = new ContratoEntity();

                contrato.NumeroContrato = fila.Numero;
                contrato.Creacion = fila.Creacion;
                contrato.Termino = fila.Termino;
                contrato.Cliente = clienteDAO.BuscarPorRut(fila.RutCliente); // Si no lo encuentra, queda nulo
                contrato.Tipo = tipoEventoDAO.BuscarPorId(fila.IdTipoEvento);
                contrato.ModalidadServicio = modalidadServicioDAO.BuscarPorId(fila.IdModalidad);
                contrato.InicioEvento = fila.FechaHoraInicio;
                contrato.TerminoEvento = fila.FechaHoraTermino;
                contrato.Asistentes = fila.Asistentes;
                contrato.PersonalAdicional = fila.PersonalAdicional;
                contrato.Realizado = fila.Realizado;
                contrato.PrecioTotal = fila.ValorTotalContrato;

            }


            return contratos;
        }


        public void Crear(ContratoEntity contrato)
        {

            //Creacion de objeto Adaptador  de la tabla Cliente que 
            //posee el CRUD
            ContratoTableAdapter adapter =
                    new ContratoTableAdapter();

            //Llamamos al método insertar del adaptador
            adapter.Insert(contrato.NumeroContrato, contrato.Creacion, contrato.Termino, contrato.Cliente.Rut, contrato.ModalidadServicio.Id, contrato.Tipo.Id, contrato.InicioEvento, contrato.TerminoEvento, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.PrecioTotal, contrato.Observaciones);
        }

        public void Eliminar(string numero)
        {
            ContratoTableAdapter adapter = new ContratoTableAdapter();

            adapter.EliminarPorNumero(numero);
        }

        public void Modificar(ContratoEntity contrato)
        {
            ContratoTableAdapter adapter = new ContratoTableAdapter();

            adapter.Modificar(contrato.Creacion, contrato.Termino, contrato.Cliente.Rut, contrato.ModalidadServicio.Id, contrato.Tipo.Id, contrato.InicioEvento, contrato.TerminoEvento, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.PrecioTotal, contrato.Observaciones, contrato.NumeroContrato);
        }

  
    }

 



}
