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
    public class TipoEventoDAO
    {
        public TipoEventoEntity BuscarPorId(int id)
        {
            TipoEventoEntity tipoEvento = null;

            TipoEventoTableAdapter adapter = new TipoEventoTableAdapter();

            TipoEventoRow fila = adapter.BuscarPorId(id).FirstOrDefault();

            if(fila != null)
            {

                if (fila.IdTipoEvento == CoffeeBreakDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CoffeeBreakEntity();
                }
                else if (fila.IdTipoEvento == CocktailDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CocktailEntity();
                }
                else if (fila.IdTipoEvento == CenaDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CenaEntity();
                }
                else
                {
                    tipoEvento = new TipoEventoEntity();
                }


                tipoEvento.Id = fila.IdTipoEvento;
                tipoEvento.Descripcion = fila.Descripcion;
            }

            return tipoEvento;
        }

        /// <summary>
        /// Devuelve la lista completa de Tipos de Evento
        /// </summary>
        /// <returns>Lista de TipoEventoEntity en la base de datos</returns>
        public List<TipoEventoEntity> BuscarTodo()
        {
            List<TipoEventoEntity> tiposEvento = new List<TipoEventoEntity>();

            TipoEventoTableAdapter tiposEventoAdapter = new TipoEventoTableAdapter();

            foreach(TipoEventoRow fila in tiposEventoAdapter.GetData())
            {
                TipoEventoEntity tipoEvento = null;

                if (fila.IdTipoEvento == CoffeeBreakDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CoffeeBreakEntity();
                }
                else if (fila.IdTipoEvento == CocktailDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CocktailEntity();
                }
                else if (fila.IdTipoEvento == CenaDAO.ReferenciaIdTipoEvento)
                {
                    tipoEvento = new CenaEntity();
                }
                else
                {
                    tipoEvento = new TipoEventoEntity();
                }

                tipoEvento.Id = fila.IdTipoEvento;
                tipoEvento.Descripcion = fila.Descripcion;

                tiposEvento.Add(tipoEvento);
            }

            return tiposEvento;
        }
    }
}
