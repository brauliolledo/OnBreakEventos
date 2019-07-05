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
    public class RegistroContratoDAO
    {
        private RegistroContrato2TableAdapter adapter;

        public RegistroContratoDAO()
        {
            adapter = new RegistroContrato2TableAdapter();
        }

        public void Insertar(ContratoEntity contrato)
        {
            adapter.Insert(contrato.NumeroContrato);
        }

        public List<ContratoEntity> BuscarTodo()
        {

            List<ContratoEntity> contrato = new List<ContratoEntity>();

            foreach (RegistroContrato2Row fila
                in adapter.GetData())
            {
                ContratoEntity p = new ContratoEntity();
                p.NumeroContrato = fila.Numero;

                contrato.Add(p);
            }

            return contrato;
        }
    }
}
