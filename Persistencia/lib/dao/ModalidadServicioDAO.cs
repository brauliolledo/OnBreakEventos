using Persistencia.lib.entity;
using Persistencia.OnBreakDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Persistencia.OnBreakDataSet;

namespace Persistencia.lib.dao
{
    public class ModalidadServicioDAO
    {
        private TipoEventoDAO tipoEventoDao;

        public ModalidadServicioDAO()
        {
            tipoEventoDao = new TipoEventoDAO();
        }

        public List<ModalidadServicioEntity> BuscarTodo()
        {
            List<ModalidadServicioEntity> modalidadesServicio = new List<ModalidadServicioEntity>();

            ModalidadServicioTableAdapter modalidadServicioAdapter = new ModalidadServicioTableAdapter();

            foreach (ModalidadServicioRow fila in modalidadServicioAdapter.GetData())
            {
                modalidadesServicio.Add(new ModalidadServicioEntity
                {
                    Id = fila.IdModalidad,
                    TipoEvento = tipoEventoDao.BuscarPorId(fila.IdTipoEvento), // El primero o nulo
                    Nombre = fila.Nombre,
                    ValorBase = fila.ValorBase,
                    PersonalBase = fila.PersonalBase
            });
            }

            return modalidadesServicio;
        }

        public ModalidadServicioEntity BuscarPorId(string id)
        {
            ModalidadServicioEntity modalidadServicio = null;

            ModalidadServicioTableAdapter adapter = new ModalidadServicioTableAdapter();

            ModalidadServicioRow fila = adapter.BuscarPorId(id).FirstOrDefault();

            if(fila != null)
            {
                modalidadServicio = new ModalidadServicioEntity();

                modalidadServicio.Id = fila.IdModalidad; 
                modalidadServicio.TipoEvento = tipoEventoDao.BuscarPorId(fila.IdTipoEvento); // El primero o nulo
                modalidadServicio.Nombre = fila.Nombre.Replace("\t", "");
                modalidadServicio.ValorBase = fila.ValorBase;
                modalidadServicio.PersonalBase = fila.PersonalBase;
            }


            return modalidadServicio;
        }

        public List<ModalidadServicioEntity> BuscarPorIdTipoEvento(int idTipoEvento)
        {
            List<ModalidadServicioEntity> modalidades = new List<ModalidadServicioEntity>();

            ModalidadServicioTableAdapter adapter = new ModalidadServicioTableAdapter();

            foreach(ModalidadServicioRow fila in adapter.BuscarPorIdTipoEvento(idTipoEvento))
            {
                ModalidadServicioEntity modalidadServicio = new ModalidadServicioEntity();

                modalidadServicio.Id = fila.IdModalidad;
                modalidadServicio.Nombre = fila.Nombre;
                modalidadServicio.PersonalBase = fila.PersonalBase;
                modalidadServicio.ValorBase = fila.ValorBase;
                modalidadServicio.TipoEvento = tipoEventoDao.BuscarPorId(idTipoEvento);

                modalidades.Add(modalidadServicio);
            }

            return modalidades;
        }
    }
}
