using Persistencia.lib.entity;
using Persistencia.OnBreakDataSetTableAdapters;
using System.Linq;
using static Persistencia.OnBreakDataSet;

namespace Persistencia.lib.dao
{
    public class CenaDAO
    {
        public static int ReferenciaIdTipoEvento = 30;

        private TipoEventoDAO tipoEventoDAO;
        private TipoAmbientacionDAO tipoAmbientacionDAO;

        public CenaDAO()
        {
            tipoEventoDAO = new TipoEventoDAO();
            tipoAmbientacionDAO = new TipoAmbientacionDAO();
        }

        public CenaEntity BuscarPorNumeroContrato(string numeroContrato)
        {
            CenasTableAdapter cenasTableAdapter = new CenasTableAdapter();

            CenasRow fila = cenasTableAdapter.ObtenerPorNumeroContrato(numeroContrato).FirstOrDefault();

            TipoEventoEntity tipoEvento = tipoEventoDAO.BuscarPorId(ReferenciaIdTipoEvento);

            return new CenaEntity()
            {
                Id = tipoEvento.Id,
                Descripcion = tipoEvento.Descripcion,
                Ambientacion = tipoAmbientacionDAO.ObtenerPorId(fila.IdTipoAmbientacion),
                LocalOnBreak = fila.LocalOnBreak,
                OtroLocal = fila.OtroLocalOnBreak,
                MusicaAmbiental = fila.MusicaAmbiental,
                ValorArriendo = fila.ValorArriendo
            };
        }

        public void EliminarPorNumeroContrato(string numeroContrato)
        {
            CenasTableAdapter cenasTableAdapter = new CenasTableAdapter();

            cenasTableAdapter.BorrarPorNumeroContrato(numeroContrato);
        }

        public void ModificarPorNumeroContrato(CenaEntity cena, string numeroContrato)
        {
            CenasTableAdapter cenasTableAdapter = new CenasTableAdapter();


            cenasTableAdapter.ModificarPorNumeroContrato(cena.Ambientacion.Id,
                                                         cena.MusicaAmbiental,
                                                         cena.LocalOnBreak,
                                                         cena.OtroLocal,
                                                         cena.ValorArriendo,
                                                         numeroContrato);
        }

        public void Insertar(CenaEntity cena, string numeroContrato)
        {
            CenasTableAdapter cenasTableAdapter = new CenasTableAdapter();

            cenasTableAdapter.Insert(numeroContrato,
                                     cena.Ambientacion.Id,
                                     cena.MusicaAmbiental,
                                     cena.LocalOnBreak,
                                     cena.OtroLocal,
                                     cena.ValorArriendo);
        }
    }
}
