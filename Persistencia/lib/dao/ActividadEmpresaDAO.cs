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
    public class ActividadEmpresaDAO
    {


        public ActividadEmpresaDAO() {
        }

        public List<ActividadEmpresaEntity> BuscarTodo() {

            List<ActividadEmpresaEntity> actividadE =
                new List<ActividadEmpresaEntity>();

            ActividadEmpresaTableAdapter adapter =
                new ActividadEmpresaTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ActividadEmpresaRow
                        fila in adapter.GetData()) {
                ActividadEmpresaEntity tipo
                    = new ActividadEmpresaEntity(
                        fila.IdActividadEmpresa, fila.Descripcion);
                actividadE.Add(tipo);
            }

            return actividadE;
        }

        public ActividadEmpresaEntity BuscarPorId(int id)
        {

            ActividadEmpresaEntity actividad =
                new ActividadEmpresaEntity();

            ActividadEmpresaTableAdapter adapter =
                new ActividadEmpresaTableAdapter();
            //Recorrer tabla por fila y crear objeto
            //con la información de la fila
            foreach (ActividadEmpresaRow
                        fila in adapter.BuscarPorId(id))
            {
                actividad
                    = new ActividadEmpresaEntity(
                        fila.IdActividadEmpresa, fila.Descripcion);
            }

            return actividad;
        }
    }
}
