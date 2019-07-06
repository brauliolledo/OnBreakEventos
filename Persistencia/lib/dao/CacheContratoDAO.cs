using Persistencia.lib.entity;
using Persistencia.OnBreakDataSetTableAdapters;
using Persitencia.lib.memento;
using Presentacion.app.lib;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Persistencia.OnBreakDataSet;

namespace Persistencia.lib.dao
{
    public class CacheContratoDAO
    {
        private ClienteDAO clienteDAO;
        private TipoEventoDAO tipoEventoDAO;
        private ModalidadServicioDAO modalidadServicioDAO;
        private TipoAmbientacionDAO tipoAmbientacionDAO;

        public CacheContratoDAO()
        {
            clienteDAO = new ClienteDAO();
            tipoEventoDAO = new TipoEventoDAO();
            modalidadServicioDAO = new ModalidadServicioDAO();
            tipoAmbientacionDAO = new TipoAmbientacionDAO();
        }

        public ContratoEntity ContratoEntityDesdeFila(CacheContratoRow fila)
        {
            ContratoEntity contrato;

            TipoEventoEntity tipoEventoBase = null;
            TipoEventoEntity tipoEvento = null;

            if (fila.IsIdTipoEventoNull() != true)
            {
                tipoEventoBase = tipoEventoDAO.BuscarPorId(fila.IdTipoEvento);


                if (fila.IdTipoEvento == CoffeeBreakDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CoffeeBreakEntity()
                    {
                        Id = fila.IdTipoEvento,
                        Descripcion = tipoEventoBase.Descripcion,
                        Vegetariana = fila.Vegetariana
                    };
                }
                else if (fila.IdTipoEvento == CocktailDAO.ReferenciaIdTipoEvento)
                {

                    TipoAmbientacionEntity tipoAmbientacion = null;

                    if(fila.IsIdTipoAmbientacionNull() == false)
                        tipoAmbientacion = tipoAmbientacionDAO.ObtenerPorId(fila.IdTipoAmbientacion);

                    tipoEvento = new CocktailEntity()
                    {
                        Id = fila.IdTipoEvento,
                        Descripcion = tipoEventoBase.Descripcion,
                        Ambientacion = (tipoAmbientacion == null) ? new NullTipoAmbientacionEntity() : tipoAmbientacion,
                        MusicaAmbiental = fila.MusicaAmbiental,
                        MusicaCliente = fila.MusicaCliente
                    };
                }
                else if (fila.IdTipoEvento == CenaDAO.ReferenciaIdTipoEvento)
                {
                    TipoAmbientacionEntity tipoAmbientacion = null;

                    if (fila.IsIdTipoAmbientacionNull() == false)
                        tipoAmbientacion = tipoAmbientacionDAO.ObtenerPorId(fila.IdTipoAmbientacion);


                    tipoEvento = new CenaEntity()
                    {
                        Id = fila.IdTipoEvento,
                        Descripcion = tipoEventoBase.Descripcion,
                        Ambientacion = (tipoAmbientacion == null) ? new NullTipoAmbientacionEntity() : tipoAmbientacion,
                        MusicaAmbiental = fila.MusicaAmbiental,
                        LocalOnBreak = fila.LocalOnBreak,
                        OtroLocal = fila.OtroLocalOnBreak,
                        ValorArriendo = fila.ValorArriendo
                    };
                }
                else
                {
                    tipoEvento = tipoEventoBase;
                }
            }

            ClienteEntity cliente;

            cliente = (fila.IsRutClienteNull() == true) ? new NullClienteEntity() : clienteDAO.BuscarPorRut(fila.RutCliente);

            if (cliente == null)
                cliente = new NullClienteEntity();

            ModalidadServicioEntity modalidad = null;

            if (fila.IsIdModalidadNull() != true)
            {
                modalidad = modalidadServicioDAO.BuscarPorId(fila.IdModalidad);
            }

            if (fila.IsNumeroContratoNull() == true)
            {


                contrato = new NullContratoEntity()
                {
                    NumeroContrato = (fila.IsNumeroContratoNull() == true) ? null : fila.NumeroContrato,
                    Creacion = (fila.IsCreacionNull() == true) ? (DateTime) SqlDateTime.MinValue : fila.Creacion,
                    Termino = (fila.IsTerminoNull() == true) ? (DateTime) SqlDateTime.MinValue : fila.Termino,
                    Cliente = cliente,
                    InicioEvento = (fila.IsFechaHoraInicioNull() == true) ? (DateTime)SqlDateTime.MinValue : fila.FechaHoraInicio,
                    TerminoEvento = (fila.IsFechaHoraTerminoNull() == true) ? (DateTime)SqlDateTime.MinValue : fila.FechaHoraTermino,
                    Asistentes = (fila.IsAsistentesNull() == true) ? 1 : fila.Asistentes,
                    PersonalAdicional = (fila.IsPersonalAdicionalNull() == true) ? 0 : fila.PersonalAdicional,
                    Realizado = (fila.IsRealizadoNull() == true) ? false : fila.Realizado,
                    PrecioTotal = (fila.IsValorTotalContratoNull() == true) ? 0 : fila.ValorTotalContrato,
                    Observaciones = (fila.IsObservacionesNull() == true) ? null : fila.Observaciones,
                    Tipo = tipoEvento
                };

                contrato.ModalidadServicio = modalidad;
            }
            else
            {
                contrato = new ContratoEntity()
                {
                    NumeroContrato = (fila.IsNumeroContratoNull() == true) ? null : fila.NumeroContrato,
                    Creacion = (fila.IsCreacionNull() == true) ? (DateTime)SqlDateTime.MinValue : fila.Creacion,
                    Termino = (fila.IsTerminoNull() == true) ? (DateTime)SqlDateTime.MinValue : fila.Termino,
                    Cliente = cliente,
                    InicioEvento = (fila.IsFechaHoraInicioNull() == true) ? (DateTime)SqlDateTime.MinValue : fila.FechaHoraInicio,
                    TerminoEvento = (fila.IsFechaHoraTerminoNull() == true) ? (DateTime)SqlDateTime.MinValue : fila.FechaHoraTermino,
                    Asistentes = (fila.IsAsistentesNull() == true) ? 1 : fila.Asistentes,
                    PersonalAdicional = (fila.IsPersonalAdicionalNull() == true) ? 0 : fila.PersonalAdicional,
                    Realizado = (fila.IsRealizadoNull() == true) ? false : fila.Realizado,
                    PrecioTotal = (fila.IsValorTotalContratoNull() == true) ? 0 : fila.ValorTotalContrato,
                    Observaciones = (fila.IsObservacionesNull() == true) ? null : fila.Observaciones,
                    Tipo = tipoEvento
                };

                contrato.ModalidadServicio = modalidad;
            }



            return contrato;
        }

        public List<AdministracionContratoMemento> ObtenerTodos()
        {
            List<AdministracionContratoMemento> mementos = new List<AdministracionContratoMemento>();

            CacheContratoTableAdapter cacheContratoTableAdapter = new CacheContratoTableAdapter();


            foreach(CacheContratoRow fila in cacheContratoTableAdapter.ObtenerTodos())
            {
                ContratoEntity contrato;

                contrato = ContratoEntityDesdeFila(fila);

                mementos.Add(new AdministracionContratoMemento()
                {
                    FechaHora = fila.FechaHora,
                    Contrato = contrato
                });
            }

            return mementos;
        }

        public void Insertar(AdministracionContratoMemento administracionContratoMemento)
        {


            CacheContratoTableAdapter cacheContratoTableAdapter = new CacheContratoTableAdapter();

            int? IdTipoAmbientacion = null;
            bool MusicaAmbiental = false;
            bool LocalOnBreak = false;
            bool OtroLocalOnBreak = false;
            double ValorArriendo = 0;
            bool MusicaCliente = false;
            bool Vegetariana = false;

            int? tipoId = (administracionContratoMemento.Contrato.Tipo == null) ? null : administracionContratoMemento.Contrato.Tipo.Id as int?;

            if (administracionContratoMemento.Contrato.Tipo is CoffeeBreakEntity)
            {
                Vegetariana = (administracionContratoMemento.Contrato.Tipo as CoffeeBreakEntity).Vegetariana;
            }
            else if (administracionContratoMemento.Contrato.Tipo is CocktailEntity)
            {
                TipoAmbientacionEntity tipoAmbientacion = (administracionContratoMemento.Contrato.Tipo as CocktailEntity).Ambientacion;

                if (tipoAmbientacion != null && !(tipoAmbientacion is NullTipoAmbientacionEntity))
                {
                    IdTipoAmbientacion = tipoAmbientacion.Id;
                }

                MusicaAmbiental = (administracionContratoMemento.Contrato.Tipo as CocktailEntity).MusicaAmbiental;
                MusicaCliente = (administracionContratoMemento.Contrato.Tipo as CocktailEntity).MusicaCliente;
            }
            else if(administracionContratoMemento.Contrato.Tipo is CenaEntity)
            {
                TipoAmbientacionEntity tipoAmbientacion = (administracionContratoMemento.Contrato.Tipo as CenaEntity).Ambientacion;

                if (tipoAmbientacion != null && !(tipoAmbientacion is NullTipoAmbientacionEntity))
                {
                    IdTipoAmbientacion = tipoAmbientacion.Id;
                }

                MusicaAmbiental = (administracionContratoMemento.Contrato.Tipo as CenaEntity).MusicaAmbiental;
                LocalOnBreak = (administracionContratoMemento.Contrato.Tipo as CenaEntity).LocalOnBreak;
                OtroLocalOnBreak = (administracionContratoMemento.Contrato.Tipo as CenaEntity).OtroLocal;
                ValorArriendo = (administracionContratoMemento.Contrato.Tipo as CenaEntity).ValorArriendo;
            }

            cacheContratoTableAdapter.Insert(administracionContratoMemento.Contrato.NumeroContrato,
                administracionContratoMemento.FechaHora, administracionContratoMemento.Contrato.Creacion,
                (administracionContratoMemento.Contrato.Cliente == null) ? null : administracionContratoMemento.Contrato.Cliente.Rut,

                (administracionContratoMemento.Contrato.ModalidadServicio == null) ? null : administracionContratoMemento.Contrato.ModalidadServicio.Id,
                tipoId, administracionContratoMemento.Contrato.InicioEvento,
                administracionContratoMemento.Contrato.TerminoEvento, administracionContratoMemento.Contrato.Asistentes,
                administracionContratoMemento.Contrato.PersonalAdicional, administracionContratoMemento.Contrato.Realizado,
                administracionContratoMemento.Contrato.PrecioTotal, administracionContratoMemento.Contrato.Observaciones, 
                IdTipoAmbientacion, MusicaAmbiental, LocalOnBreak, OtroLocalOnBreak, ValorArriendo, MusicaCliente, Vegetariana
                );
        }

        public void BorrarTodo()
        {
            CacheContratoTableAdapter cacheContratoTableAdapter = new CacheContratoTableAdapter();

            cacheContratoTableAdapter.BorrarTodo();
        }
    }
}
