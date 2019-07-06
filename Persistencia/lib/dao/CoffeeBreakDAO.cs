using Persistencia.lib.entity;
using Persistencia.OnBreakDataSetTableAdapters;
using System.Linq;
using static Persistencia.OnBreakDataSet;

namespace Persistencia.lib.dao
{
    public class CoffeeBreakDAO
    {
        public static int ReferenciaIdTipoEvento = 10;

        private TipoEventoDAO tipoEventoDAO;

        public CoffeeBreakDAO()
        {
            tipoEventoDAO = new TipoEventoDAO();
        }

        public CoffeeBreakEntity BuscarPorNumeroContrato(string numeroContrato)
        {
            CoffeeBreakTableAdapter coffeBreakTableAdapter = new CoffeeBreakTableAdapter();

            CoffeeBreakRow fila = coffeBreakTableAdapter.ObtenerPorNumeroContrato(numeroContrato).FirstOrDefault();

            TipoEventoEntity tipoEvento = tipoEventoDAO.BuscarPorId(ReferenciaIdTipoEvento);

            return new CoffeeBreakEntity()
            {
                Id = tipoEvento.Id,
                Descripcion = tipoEvento.Descripcion,
                Vegetariana = fila.Vegetariana
            };
        }

        public void EliminarPorNumeroContrato(string numeroContrato)
        {
            CoffeeBreakTableAdapter coffeeBreakTableAdapter = new CoffeeBreakTableAdapter();

            coffeeBreakTableAdapter.BorrarPorNumeroContrato(numeroContrato);
        }

        public void ModificarPorNumeroContrato(CoffeeBreakEntity coffeeBreak, string numeroContrato)
        {
            CoffeeBreakTableAdapter coffeeBreakTableAdapter = new CoffeeBreakTableAdapter();


            coffeeBreakTableAdapter.ModificarPorNumeroContrato(coffeeBreak.Vegetariana, numeroContrato);
        }

        public void Insertar(CoffeeBreakEntity coffeeBreak, string numeroContrato)
        {
            CoffeeBreakTableAdapter coffeeBreakTableAdapter = new CoffeeBreakTableAdapter();

            coffeeBreakTableAdapter.Insert(numeroContrato, coffeeBreak.Vegetariana);
        }

    }
}
