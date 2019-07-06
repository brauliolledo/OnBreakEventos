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
    public class CocktailDAO
    {
        public static int ReferenciaIdTipoEvento = 20;

        private TipoEventoDAO tipoEventoDAO;
        private TipoAmbientacionDAO tipoAmbientacionDAO;


        public CocktailDAO()
        {
            tipoEventoDAO = new TipoEventoDAO();
            tipoAmbientacionDAO = new TipoAmbientacionDAO();
        }

        public CocktailEntity BuscarPorNumeroContrato(string numeroContrato)
        {
            CocktailTableAdapter cocktailTableAdapter = new CocktailTableAdapter();

            CocktailRow fila = cocktailTableAdapter.ObtenerPorNumeroContrato(numeroContrato).FirstOrDefault();

            TipoEventoEntity tipoEvento = tipoEventoDAO.BuscarPorId(ReferenciaIdTipoEvento);


            return new CocktailEntity()
            {
                Id = tipoEvento.Id,
                Descripcion = tipoEvento.Descripcion,
                Ambientacion = (fila.IsIdTipoAmbientacionNull() == true) ? new NullTipoAmbientacionEntity() : tipoAmbientacionDAO.ObtenerPorId(fila.IdTipoAmbientacion),
                MusicaAmbiental = fila.MusicaAmbiental,
                MusicaCliente = fila.MusicaCliente
            };
        }

        public void EliminarPorNumeroContrato(string numeroContrato)
        {
            CocktailTableAdapter cocktailTableAdapter = new CocktailTableAdapter();

            cocktailTableAdapter.BorrarPorNumeroContrato(numeroContrato);
        }

        public void ModificarPorNumeroContrato(CocktailEntity cocktail, string numeroContrato)
        {
            CocktailTableAdapter cocktailTableAdapter = new CocktailTableAdapter();

            cocktailTableAdapter.ModificarPorNumeroContrato((cocktail.Ambientacion is NullTipoAmbientacionEntity) ? null : cocktail.Ambientacion.Id as int?,
                                                            cocktail.Ambientacion is NullTipoAmbientacionEntity,
                                                            cocktail.MusicaAmbiental,
                                                            cocktail.MusicaCliente,
                                                            numeroContrato);
        }

        public void Insertar(CocktailEntity cocktail, string numeroContrato)
        {
            CocktailTableAdapter cocktailTableAdapter = new CocktailTableAdapter();

            cocktailTableAdapter.Insert(numeroContrato,
                                        (cocktail.Ambientacion is NullTipoAmbientacionEntity) ? null : cocktail.Ambientacion.Id as int?,
                                        cocktail.Ambientacion is NullTipoAmbientacionEntity,
                                        cocktail.MusicaAmbiental,
                                        cocktail.MusicaCliente);
        }


    }
}
