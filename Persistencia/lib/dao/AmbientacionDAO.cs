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
    public class TipoAmbientacionDAO
    {
        public TipoAmbientacionEntity ObtenerPorId(int id)
        {
            TipoAmbientacionTableAdapter ambientacionTableAdapter = new TipoAmbientacionTableAdapter();

            TipoAmbientacionRow fila = ambientacionTableAdapter.ObtenerPorId(id).FirstOrDefault();

            return new TipoAmbientacionEntity()
            {
                Id = fila.IdTipoAmbientacion,
                Descripcion = fila.Descripcion
            };
        }

        public List<TipoAmbientacionEntity> ObtenerTodo()
        {
            TipoAmbientacionTableAdapter ambientacionTableAdapter = new TipoAmbientacionTableAdapter();

            List<TipoAmbientacionEntity> tiposAmbientacion = new List<TipoAmbientacionEntity>();

            foreach(TipoAmbientacionRow fila in ambientacionTableAdapter.ObtenerTodos())
            {
                tiposAmbientacion.Add(
                    new TipoAmbientacionEntity()
                    {
                        Id = fila.IdTipoAmbientacion,
                        Descripcion = fila.Descripcion
                    });
            }

            return tiposAmbientacion;
        }
    }
}
