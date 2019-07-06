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

        private CoffeeBreakDAO coffeeBreakDAO;
        private CocktailDAO cocktailDAO;
        private CenaDAO cenaDAO;


        public ContratoDAO()
        {
            clienteDAO = new ClienteDAO();
            tipoEventoDAO = new TipoEventoDAO();
            modalidadServicioDAO = new ModalidadServicioDAO();
            coffeeBreakDAO = new CoffeeBreakDAO();
            cocktailDAO = new CocktailDAO();
            cenaDAO = new CenaDAO();
        }

        public ContratoEntity ContratoEntityDesdeFila(ContratoRow fila)
        {
            TipoEventoEntity tipoEvento = null;

            if(fila.IdTipoEvento == CoffeeBreakDAO.ReferenciaIdTipoEvento)
            {
                tipoEvento = coffeeBreakDAO.BuscarPorNumeroContrato(fila.Numero);
            }
            else if(fila.IdTipoEvento == CocktailDAO.ReferenciaIdTipoEvento)
            {
                tipoEvento = cocktailDAO.BuscarPorNumeroContrato(fila.Numero);
            }
            else if(fila.IdTipoEvento == CenaDAO.ReferenciaIdTipoEvento)
            {
                tipoEvento = cenaDAO.BuscarPorNumeroContrato(fila.Numero);
            }
            else
            {
                tipoEvento = tipoEventoDAO.BuscarPorId(fila.IdTipoEvento);
            }

            return new ContratoEntity()
            {
                NumeroContrato = fila.Numero,
                Creacion = fila.Creacion,
                Termino = fila.Termino,
                Cliente = clienteDAO.BuscarPorRut(fila.RutCliente),
                Tipo = tipoEvento,
                ModalidadServicio = modalidadServicioDAO.BuscarPorId(fila.IdModalidad),
                InicioEvento = fila.FechaHoraInicio,
                TerminoEvento = fila.FechaHoraTermino,
                Asistentes = fila.Asistentes,
                PersonalAdicional = fila.PersonalAdicional,
                Realizado = fila.Realizado,
                PrecioTotal = fila.ValorTotalContrato,
                Observaciones = fila.Observaciones
            };
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
                return ContratoEntityDesdeFila(filaCoincidente);
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
                contratos.Add(ContratoEntityDesdeFila(fila));
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
                contratos.Add(ContratoEntityDesdeFila(fila));
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
                contratos.Add(ContratoEntityDesdeFila(fila));
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
                contratos.Add(ContratoEntityDesdeFila(fila));

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
            adapter.Insert(contrato.NumeroContrato, contrato.Creacion, contrato.Termino, contrato.Cliente.Rut, contrato.ModalidadServicio.Id, contrato.Tipo.Id, contrato.InicioEvento, contrato.TerminoEvento, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.PrecioTotal, (contrato.Observaciones == null) ? "" : contrato.Observaciones);

            if (contrato.Tipo.Id == CoffeeBreakDAO.ReferenciaIdTipoEvento)
            {
                coffeeBreakDAO.Insertar(contrato.Tipo as CoffeeBreakEntity, contrato.NumeroContrato);
            }
            else if (contrato.Tipo.Id == CocktailDAO.ReferenciaIdTipoEvento)
            {
                cocktailDAO.Insertar(contrato.Tipo as CocktailEntity, contrato.NumeroContrato);
            }
            else if (contrato.Tipo.Id == CenaDAO.ReferenciaIdTipoEvento)
            {
                cenaDAO.Insertar(contrato.Tipo as CenaEntity, contrato.NumeroContrato);
            }

        }

        public void Eliminar(ContratoEntity contrato)
        {
            ContratoTableAdapter adapter = new ContratoTableAdapter();

            if (contrato.Tipo.Id == CoffeeBreakDAO.ReferenciaIdTipoEvento)
            {
                coffeeBreakDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
            }
            else if (contrato.Tipo.Id == CocktailDAO.ReferenciaIdTipoEvento)
            {
                cocktailDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
            }
            else if (contrato.Tipo.Id == CenaDAO.ReferenciaIdTipoEvento)
            {
                cenaDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
            }


            adapter.EliminarPorNumero(contrato.NumeroContrato);
        }

        public void Modificar(ContratoEntity contrato)
        {
            ContratoTableAdapter adapter = new ContratoTableAdapter();

            // Buscamos el contrato antiguo y preguntamos por el tipoId

            ContratoEntity contratoAntiguo = BuscarPorNumero(contrato.NumeroContrato);

            bool cambioTipoContrato = false;

            if(contratoAntiguo.Tipo.Id != contrato.Tipo.Id)
            {
                cambioTipoContrato = true;
            }


            if (contrato.Tipo.Id == CoffeeBreakDAO.ReferenciaIdTipoEvento)
            {
                if(cambioTipoContrato == true)
                {
                    if(contratoAntiguo.Tipo.Id == CoffeeBreakDAO.ReferenciaIdTipoEvento)
                    {
                        coffeeBreakDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }
                    else if (contratoAntiguo.Tipo.Id == CocktailDAO.ReferenciaIdTipoEvento)
                    {
                        cocktailDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }
                    else if (contratoAntiguo.Tipo.Id == CenaDAO.ReferenciaIdTipoEvento)
                    {
                        cenaDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }

                    coffeeBreakDAO.Insertar(contrato.Tipo as CoffeeBreakEntity, contrato.NumeroContrato);
                }
                else
                {
                    coffeeBreakDAO.ModificarPorNumeroContrato(contrato.Tipo as CoffeeBreakEntity, contrato.NumeroContrato);
                }
            }
            else if (contrato.Tipo.Id == CocktailDAO.ReferenciaIdTipoEvento)
            {
                if (cambioTipoContrato == true)
                {
                    if (contratoAntiguo.Tipo.Id == CoffeeBreakDAO.ReferenciaIdTipoEvento)
                    {
                        coffeeBreakDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }
                    else if (contratoAntiguo.Tipo.Id == CocktailDAO.ReferenciaIdTipoEvento)
                    {
                        cocktailDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }
                    else if (contratoAntiguo.Tipo.Id == CenaDAO.ReferenciaIdTipoEvento)
                    {
                        cenaDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }

                    cocktailDAO.Insertar(contrato.Tipo as CocktailEntity, contrato.NumeroContrato);
                }
                else
                {
                    cocktailDAO.ModificarPorNumeroContrato(contrato.Tipo as CocktailEntity, contrato.NumeroContrato);
                }
            }
            else if (contrato.Tipo.Id == CenaDAO.ReferenciaIdTipoEvento)
            {
                if (cambioTipoContrato == true)
                {
                    if (contratoAntiguo.Tipo.Id == CoffeeBreakDAO.ReferenciaIdTipoEvento)
                    {
                        coffeeBreakDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }
                    else if (contratoAntiguo.Tipo.Id == CocktailDAO.ReferenciaIdTipoEvento)
                    {
                        cocktailDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }
                    else if (contratoAntiguo.Tipo.Id == CenaDAO.ReferenciaIdTipoEvento)
                    {
                        cenaDAO.EliminarPorNumeroContrato(contrato.NumeroContrato);
                    }

                    cenaDAO.Insertar(contrato.Tipo as CenaEntity, contrato.NumeroContrato);
                }
                else
                {
                    cenaDAO.ModificarPorNumeroContrato(contrato.Tipo as CenaEntity, contrato.NumeroContrato);
                }
            }

            adapter.Modificar(contrato.Creacion, contrato.Termino, contrato.Cliente.Rut, contrato.ModalidadServicio.Id, contrato.Tipo.Id, contrato.InicioEvento, contrato.TerminoEvento, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.PrecioTotal, (contrato.Observaciones == null) ? "" : contrato.Observaciones, contrato.NumeroContrato);
        }

  
    }

 



}
