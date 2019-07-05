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
    public class TipoEmpresaDAO
    {
        public TipoEmpresaDAO() {
        }

        public List<TipoEmpresaEntity> BuscarTodo() {

            List<TipoEmpresaEntity> tiposE =
                new List<TipoEmpresaEntity>();

            TipoEmpresaTableAdapter adapter =
                new TipoEmpresaTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (TipoEmpresaRow
                        fila in adapter.GetData()) {
                TipoEmpresaEntity tipo
                    = new TipoEmpresaEntity(
                        fila.IdTipoEmpresa, fila.Descripcion);
                tiposE.Add(tipo);
            }

            return tiposE;
        }

        public TipoEmpresaEntity BuscarPorId(int id) 
        {

            TipoEmpresaEntity tipoEmpresa =
                new TipoEmpresaEntity();

            TipoEmpresaTableAdapter adapter =
                new TipoEmpresaTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (TipoEmpresaRow
                        fila in adapter.BuscarPorId(id))
            {
                tipoEmpresa
                    = new TipoEmpresaEntity(
                        fila.IdTipoEmpresa, fila.Descripcion);
            }

            return tipoEmpresa;
        }
    }
}
